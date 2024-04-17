using System.Text.Json.Serialization;

namespace main.dto
{
    public class TeamDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}
