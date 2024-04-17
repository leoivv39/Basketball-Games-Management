using main.dto;
using main.events;
using main.extension;
using main.parser;
using main.request;
using main.response;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace client.gateway
{
    public class ServerGateway : IServerGateway
    {
        private int _port;
        private string _hostName;
        private IPEndPoint _ipEndPoint;
        private IPAddress _ipAddr;
        private IListenableContext _listenableContext;

        public ServerGateway(string hostName, int port, IListenableContext listenableContext)
        {
            _hostName = hostName;
            _port = port;
            IPHostEntry ipHost = Dns.GetHostEntry(_hostName);
            _ipAddr = ipHost.AddressList[0];
            _ipEndPoint = new(_ipAddr, _port);
            _listenableContext = listenableContext;
        }

        public Response Send(Request request)
        {
            Socket socket = new(_ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(_ipEndPoint);
            string requestJson = JsonParser.ParseToString(request);
            socket.WriteString(requestJson);

            string responseJson = socket.ReadString();
            Response response = JsonParser.ParseToResponse(responseJson);
            return response;
        }

        public void ListenForEvents()
        {
            Socket socket = new(_ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(_ipEndPoint);
            string requestJson = JsonParser.ParseToString(new Request
            {
                RequestType = RequestType.ListenToEvents
            });
            socket.WriteString(requestJson);

            while (true)
            {
                HandleServerEvent(socket);
            }
        }

        private void HandleServerEvent(Socket socket)
        {
            string eventJson = socket.ReadString();
            new Thread(() =>
            {
                Event _event = JsonParser.ParseToEvent(eventJson);
                if (_event.Type.Equals(EventType.NewSoldTicket))
                {
                    var newTicket = (SoldTicketDto)_event.Payload.Data;
                    _listenableContext.NewSoldTicketListenable.NotifyAllListeners(newTicket);
                }
            }).Start();
        }
    }
}
