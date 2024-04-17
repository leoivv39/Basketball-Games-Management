using main.response;

namespace main.controller
{
    public interface IGameController
    {
        Response GetAllGames();
        Response GetAllAvailableGames();
    }
}
