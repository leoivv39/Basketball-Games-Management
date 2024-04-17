using main.dto;
using main.payload;
using main.response;
using main.facade;

namespace main.controller
{
    public class SoldTicketController : ISoldTicketController
    {
        private ISoldTicketFacade _soldTicketFacade;

        public SoldTicketController(ISoldTicketFacade soldTicketFacade)
        {
            _soldTicketFacade = soldTicketFacade;
        }

        public Response AddSoldTicket(SoldTicketDto soldTicketDto)
        {
            SoldTicketDto savedTicket = _soldTicketFacade.AddSoldTicket(soldTicketDto);
            return new Response
            {
                Status = ResponseStatus.Ok,
                Payload = new Payload
                {
                    Type = PayloadType.SoldTicket,
                    Data = savedTicket
                }
            };
        }
    }
}
