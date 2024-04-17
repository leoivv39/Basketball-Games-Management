using client.gateway;
using main.dto;
using main.request;
using main.response;
using client.exception;
using main.payload;

namespace client.service
{
    public class UserService : IUserService
    {
        private IServerGateway _serverGateway;

        public UserService(IServerGateway serverGateway)
        {
            _serverGateway = serverGateway;
        }

        public UserDto GetUserByUsernameAndPassword(UserDto userDto)
        {
            var request = new Request
            {
                RequestType = RequestType.GetUser,
                Payload = new Payload
                {
                    Type = PayloadType.User,
                    Data = userDto
                }
            };
            Response response = _serverGateway.Send(request);
            if (response.Status.Equals(ResponseStatus.NotFound))
            {
                throw new EntityNotFoundException("User not found");
            }
            return (UserDto)response.Payload.Data;
        }
    }
}
