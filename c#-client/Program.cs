using client.service;
using client.gateway;

namespace client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var listenableContext = new ListenableContext();
            var serverGateway = new ServerGateway("127.0.0.1", 6666, listenableContext);
            var userService = new UserService(serverGateway);
            var gameService = new GameService(serverGateway);
            var soldTicketService = new SoldTicketService(serverGateway, listenableContext);
            new Thread(serverGateway.ListenForEvents).Start();
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(userService, gameService, soldTicketService));
        }
    }
}