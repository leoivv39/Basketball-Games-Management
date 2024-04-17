using client.listener;
using lab6_c_.listener;
using main.dto;
using main.request;
using main.response;

namespace client.gateway
{
    public interface IServerGateway
    {
        Response Send(Request request);
        void ListenForEvents();
    }
}
