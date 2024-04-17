using main.dto;
using main.domain;
using main.mapper;
using main.service;

namespace main.facade
{
    public class GameFacade : IGameFacade
    {
        private IGameService _gameService;
        private IGameMapper _gameMapper;

        public GameFacade(IGameService gameService, IGameMapper gameMapper)
        {
            _gameService = gameService;
            _gameMapper = gameMapper;
        }

        public IEnumerable<GameDto> AllAvailableGames
        {
            get
            {
                IEnumerable<Game> games = _gameService.AllAvailableGames;
                return _gameMapper.ToDto(games);
            }
        }

        public IEnumerable<GameDto> AllGames
        {
            get
            {
                IEnumerable<Game> games = _gameService.AllGames;
                return _gameMapper.ToDto(games);
            }
        }
    }
}
