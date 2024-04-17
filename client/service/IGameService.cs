using main.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.service
{
    public interface IGameService
    {
        IEnumerable<GameDto> AllGames { get; }
        IEnumerable<GameDto> AllAvailableGames { get; }
    }
}
