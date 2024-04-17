using main.dto;
using main.domain;

namespace main.mapper
{
    public interface ISoldTicketMapper
    {
        SoldTicketDto ToDto(SoldTicket soldTicket);
        SoldTicket ToEntity(SoldTicketDto soldTicketDto);
    }
}
