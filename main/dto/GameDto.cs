using System.Text.Json.Serialization;

namespace main.dto
{
    public class GameDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        [JsonPropertyName("firstTeam")]
        public TeamDto FirstTeam { get; set; }
        [JsonPropertyName("secondTeam")]
        public TeamDto SecondTeam { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("ticketPrice")]
        public double TicketPrice { get; set; }
        [JsonPropertyName("numberOfSeats")]
        public int NumberOfSeats { get; set; }
        [JsonPropertyName("type")]
        public GameType Type { get; set; }
    }
}
