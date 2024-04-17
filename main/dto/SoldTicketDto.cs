using System.Text.Json.Serialization;

namespace main.dto
{
    public class SoldTicketDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        [JsonPropertyName("soldBy")]
        public UserDto SoldBy { get; set; }
        [JsonPropertyName("game")]
        public GameDto Game { get; set; }
        [JsonPropertyName("soldAt")]
        public DateTime SoldAt { get; set; }
        [JsonPropertyName("noOfTickets")]
        public int NumberOfSeats { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
