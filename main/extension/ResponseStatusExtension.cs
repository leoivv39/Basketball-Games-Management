using main.response;

namespace main.extension
{
    public static class ResponseStatusExtension
    {
        public static int StatusCode(this ResponseStatus responseStatus)
        {
            return (int)responseStatus;
        }

        public static bool Successful(this ResponseStatus responseStatus)
        {
            int code = StatusCode(responseStatus);
            return code != 404 && code != 400;
        }
    }
}
