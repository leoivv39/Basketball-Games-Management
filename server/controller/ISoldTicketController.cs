using main.dto;
using main.response;

namespace main.controller
{
    public interface ISoldTicketController
    {
        Response AddSoldTicket(SoldTicketDto soldTicketDto);
    }
}
