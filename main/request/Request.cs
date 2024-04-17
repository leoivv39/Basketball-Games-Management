using main.payload;
using System.Text.Json.Serialization;

namespace main.request
{
    public class Request
    {
        [JsonPropertyName("requestType")]
        public RequestType RequestType { get; set; }
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
    }
}
