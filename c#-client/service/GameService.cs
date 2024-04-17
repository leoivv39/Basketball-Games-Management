using client.gateway;
using main.dto;
using main.request;
using main.response;

namespace client.service
{
    public class GameService : IGameService
    {
        private IServerGateway _serverGateway;

        public GameService(IServerGateway serverGateway)
        {
            _serverGateway = serverGateway;
        }

        public IEnumerable<GameDto> AllGames
        {
            get
            {
                return GetGames(RequestType.GetAllGames);
            }
        }

        public IEnumerable<GameDto> AllAvailableGames
        {
            get
            {
                return GetGames(RequestType.GetAllAvailableGames);
            }
        }

        private IEnumerable<GameDto> GetGames(RequestType requestType)
        {
            Request request = new Request
            {
                RequestType = requestType,
            };
            Response response = _serverGateway.Send(request);
            return (IEnumerable<GameDto>)response.Payload.Data;
        } 
    }
}
