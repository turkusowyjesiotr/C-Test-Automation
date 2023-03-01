using System.Text.Json.Serialization;

namespace examproject.Models
{
    public class ConfigModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }
    }

}
