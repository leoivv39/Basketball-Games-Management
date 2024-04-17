using System.Text.Json.Serialization;

namespace main.payload
{
    public class Payload
    {
        [JsonPropertyName("type")]
        public PayloadType Type { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
