using main.dto;
using main.domain;
using main.mapper;
using main.service;

namespace main.facade
{
    public class SoldTicketFacade : ISoldTicketFacade
    {
        private ISoldTicketService _soldTicketService;
        private ISoldTicketMapper _soldTicketMapper;

        public SoldTicketFacade(ISoldTicketService soldTicketService, ISoldTicketMapper soldTicketMapper)
        {
            _soldTicketService = soldTicketService;
            _soldTicketMapper = soldTicketMapper;
        }

        public SoldTicketDto AddSoldTicket(SoldTicketDto soldTicketDto)
        {
            SoldTicket soldTicket = _soldTicketMapper.ToEntity(soldTicketDto);
            SoldTicket savedTicket = _soldTicketService.AddSoldTicket(soldTicket);
            return _soldTicketMapper.ToDto(savedTicket);
        }
    }
}
