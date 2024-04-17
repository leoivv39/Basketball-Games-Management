using client.gateway;
using client.listener;
using lab6_c_.listener;
using main.dto;
using main.payload;
using main.request;
using main.response;

namespace client.service
{
    public class SoldTicketService : ISoldTicketService
    {
        private IServerGateway _serverGateway;
        private IListenableContext _listenableContext;

        public SoldTicketService(IServerGateway serverGateway, IListenableContext listenableContext)
        {
            _serverGateway = serverGateway;
            _listenableContext = listenableContext;
        }

        public SoldTicketDto AddSoldTicket(SoldTicketDto soldTicket)
        {
            var request = new Request
            {
                RequestType = RequestType.AddSoldTicket,
                Payload = new Payload
                {
                    Type = PayloadType.SoldTicket,
                    Data = soldTicket
                }
            };
            Response response = _serverGateway.Send(request);
            return (SoldTicketDto)response.Payload.Data;
        }

        public void OnNewSoldTicket(Listener<SoldTicketDto> listener)
        {
            _listenableContext.NewSoldTicketListenable.AddListener(listener);
        }
    }
}
