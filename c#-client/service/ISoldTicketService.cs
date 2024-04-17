using client.listener;
using main.dto;

namespace client.service
{
    public interface ISoldTicketService
    {
        SoldTicketDto AddSoldTicket(SoldTicketDto soldTicket);
        void OnNewSoldTicket(Listener<SoldTicketDto> listener);
    }
}
