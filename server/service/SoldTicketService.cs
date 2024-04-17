using main.repository;
using main.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.service
{
    public class SoldTicketService : ISoldTicketService
    {
        private readonly ISoldTicketRepository soldTicketRepository;
        private readonly IGameRepository gameRepository;

        public SoldTicketService(ISoldTicketRepository soldTicketRepository, IGameRepository gameRepository)
        {
            this.soldTicketRepository = soldTicketRepository;
            this.gameRepository = gameRepository;
        }

        public SoldTicket AddSoldTicket(SoldTicket soldTicket)
        {
            SoldTicket savedTicket = soldTicketRepository.Save(soldTicket) ?? throw new Exception();
            soldTicket.Game.NumberOfSeats -= soldTicket.NumberOfSeats;
            gameRepository.Update(soldTicket.Game);
            return savedTicket;
        }
    }
}
