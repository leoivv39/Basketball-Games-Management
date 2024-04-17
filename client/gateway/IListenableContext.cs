using client.listener;
using main.dto;

namespace client.gateway
{
    public interface IListenableContext
    {
        IListenable<SoldTicketDto> NewSoldTicketListenable { get; }
    }
}
