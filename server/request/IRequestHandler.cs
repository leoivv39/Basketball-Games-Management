using main.request;
using main.response;

namespace main.request
{
    public interface IRequestHandler
    {
        Response HandleRequest(Request request);
    }
}
