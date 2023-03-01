using System.Text.Json.Serialization;

namespace examproject.Models
{
    public class TestDataModel
    {
        [JsonPropertyName("variant")]
        public string Variant { get; set; }

        [JsonPropertyName("nexageProjectId")]
        public string NexageProjectId { get; set; }
    }

}
