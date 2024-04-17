using main.dto;
using main.payload;
using main.response;
using main.facade;

namespace main.controller
{
    public class GameController : IGameController
    {
        private IGameFacade _gameFacade;

        public GameController(IGameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }

        public Response GetAllAvailableGames()
        {
            IEnumerable<GameDto> games = _gameFacade.AllAvailableGames;
            return GetGamesResponse(games);
        }

        public Response GetAllGames()
        {
            IEnumerable<GameDto> games = _gameFacade.AllGames;
            return GetGamesResponse(games);
        }

        private Response GetGamesResponse(IEnumerable<GameDto> games)
        {
            return new Response
            {
                Status = ResponseStatus.Ok,
                Payload = new Payload
                {
                    Type = PayloadType.Games,
                    Data = games
                }
            };
        }
    }
}
