using main.dto;

namespace main.facade
{
    public interface IGameFacade
    {
        IEnumerable<GameDto> AllGames { get; }
        IEnumerable<GameDto> AllAvailableGames { get; }
    }
}
