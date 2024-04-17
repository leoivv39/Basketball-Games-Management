using main.dto;
using main.domain;

namespace main.facade
{
    public interface ISoldTicketFacade
    {
        SoldTicketDto AddSoldTicket(SoldTicketDto soldTicketDto);
    }
}
