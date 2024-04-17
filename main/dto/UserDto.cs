using System.Text.Json.Serialization;

namespace main.dto
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
