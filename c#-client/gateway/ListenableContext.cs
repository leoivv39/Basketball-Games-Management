using client.listener;
using lab6_c_.listener;
using main.dto;

namespace client.gateway
{
    public class ListenableContext : IListenableContext
    {
        private static readonly IListenable<SoldTicketDto> _newSoldTicketListenable = new Listenable<SoldTicketDto>();

        public IListenable<SoldTicketDto> NewSoldTicketListenable => _newSoldTicketListenable;
    }
}
