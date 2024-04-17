using main.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.service
{
    public interface IGameService
    {
        Game AddGame(Game game);
        IEnumerable<Game> AllGames { get; }
        IEnumerable<Game> AllAvailableGames { get; }
    }
}
