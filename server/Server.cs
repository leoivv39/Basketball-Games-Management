using main.request;
using main.extension;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using main.response;
using main.payload;
using main.parser;
using main.events;

namespace main
{
    public class Server
    {
        private static readonly string HostName = "127.0.0.1";
        private int _port;
        private IPEndPoint _ipEndPoint;
        private RequestHandler _requestHandler;
        private List<Socket> _listeners = new();

        public Server(int port, RequestHandler requestHandler)
        {
            _port = port;
            IPHostEntry ipHost = Dns.GetHostEntry(HostName);
            IPAddress ipAddress = ipHost.AddressList[0];
            _ipEndPoint = new(ipAddress, _port);
            _requestHandler = requestHandler;
        }

        public void Listen()
        {
            using Socket listener = new(_ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(_ipEndPoint);
            listener.Listen(100);
            while (true)
            {
                Socket clientSocket = listener.Accept();
                new Thread(() => HandleClient(clientSocket)).Start();
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            string requestJson;
            try
            {
                requestJson = clientSocket.ReadString();
            }
            catch (SocketException)
            {
                return;
            }
            Console.WriteLine($"Request: {requestJson}");
            Request request;
            try
            {
                request = JsonParser.ParseToRequest(requestJson);
            }
            catch (Exception)
            {
                Response resp = new Response
                {
                    Status = ResponseStatus.BadRequest,
                    Payload = new Payload
                    {
                        Type = PayloadType.String,
                        Data = "Invalid request payload"
                    }
                };
                string respJson = JsonParser.ParseToString(resp);
                clientSocket.WriteString(respJson);
                return;
            }
            if (request.RequestType.Equals(RequestType.ListenToEvents))
            {
                _listeners.Add(clientSocket);
                return;
            }
            Response response = _requestHandler.HandleRequest(request);
            string responseJson = JsonParser.ParseToString(response);
            clientSocket.WriteString(responseJson);
            NotifyListeners(request, response);
            clientSocket.Close();
        }

        private void NotifyListeners(Request request, Response response)
        {
            if (!response.Status.Successful())
            {
                return;
            }
            if (request.RequestType.Equals(RequestType.AddSoldTicket))
            {
                Event _event = new Event
                {
                    Type = EventType.NewSoldTicket,
                    Payload = new Payload
                    {
                        Type = PayloadType.SoldTicket,
                        Data = response.Payload.Data
                    }
                };
                _listeners.ForEach((listenerSocket) => WriteEvent(listenerSocket, _event));
            }
        }

        private void WriteEvent(Socket socket, Event _event) 
        {
            string eventJson = JsonParser.ParseToString(_event);
            socket.WriteString(eventJson);
        }
    }
}
