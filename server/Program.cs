using main;
using main.controller;
using main.facade;
using main.mapper;
using main.repository;
using main.request;
using main.service;
using System.Net;

namespace client
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var gameRepository = new GameRepository();
            var gameService = new GameService(gameRepository);
            var soldTicketRepository = new SoldTicketRepository();
            var soldTicketService = new SoldTicketService(soldTicketRepository, gameRepository);
            var userMapper = new UserMapper();
            var userFacade = new UserFacade(userService, userMapper);
            var teamMapper = new TeamMapper();
            var gameMapper = new GameMapper(teamMapper);
            var soldTicketMapper = new SoldTicketMapper(userMapper, gameMapper);
            var gameFacade = new GameFacade(gameService, gameMapper);
            var soldTicketFacade = new SoldTicketFacade(soldTicketService, soldTicketMapper);
            var userController = new UserController(userFacade);
            var gameController = new GameController(gameFacade);
            var soldTicketController = new SoldTicketController(soldTicketFacade);
            var requestHandler = new RequestHandler(userController, gameController, soldTicketController);
            var server = new Server(6666, requestHandler);
            server.Listen();
        }
    }
}