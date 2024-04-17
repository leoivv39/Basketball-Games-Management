using main.dto;
using main.request;
using main.response;
using main.controller;
using System.Text.Json;

namespace main.request
{
    public class RequestHandler : IRequestHandler
    {
        private IUserController _userController;
        private IGameController _gameController;
        private ISoldTicketController _soldTicketController;

        public RequestHandler(IUserController userController, IGameController gameController, ISoldTicketController soldTicketController)
        {
            _userController = userController;
            _gameController = gameController;
            _soldTicketController = soldTicketController;
        }

        public Response HandleRequest(Request request)
        {
            return request.RequestType switch
            {
                RequestType.GetUser => HandleGetUserRequest(request),
                RequestType.AddUser => throw new NotImplementedException(),
                RequestType.GetAllGames => HandleGetAllGamesRequest(request),
                RequestType.AddSoldTicket => HandleAddSoldTicketRequest(request),
                RequestType.GetAllAvailableGames => HandleGetAllAvailableGamesRequest(request),
                RequestType.ListenToEvents => throw new NotImplementedException(),
            };
        }

        private Response HandleGetUserRequest(Request request)
        {
            var userDto = (UserDto)request.Payload.Data;
            return _userController.GetUserByUsernameAndPassword(userDto);
        }

        private Response HandleGetAllGamesRequest(Request request)
        {
            return _gameController.GetAllGames();
        }

        private Response HandleGetAllAvailableGamesRequest(Request request)
        {
            return _gameController.GetAllAvailableGames();
        }

        private Response HandleAddSoldTicketRequest(Request request)
        {
            var soldTicketDto = (SoldTicketDto)request.Payload.Data;
            return _soldTicketController.AddSoldTicket(soldTicketDto);
        }
    }
}
