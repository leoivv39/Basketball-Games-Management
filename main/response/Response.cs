using main.payload;
using System.Text.Json.Serialization;

namespace main.response
{
    public class Response
    {
        [JsonPropertyName("status")]
        public ResponseStatus Status { get; set; }
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
    }
}
