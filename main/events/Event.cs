using main.payload;
using System.Text.Json.Serialization;

namespace main.events
{
    public class Event
    {
        [JsonPropertyName("type")]
        public EventType Type { get; set; }
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
    }
}
