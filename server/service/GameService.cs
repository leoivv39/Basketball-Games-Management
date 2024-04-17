using main.domain;
using main.repository;

namespace main.service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public Game AddGame(Game game)
        {
            return gameRepository.Save(game) ?? throw new Exception();
        }

        public IEnumerable<Game> AllAvailableGames => 
            gameRepository
            .FindAll()
            .Where(game => game.NumberOfSeats > 0);

        public IEnumerable<Game> AllGames => gameRepository.FindAll();
    }
}
