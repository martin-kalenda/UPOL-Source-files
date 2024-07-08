using System.Text.Json.Serialization;

namespace _204
{
    public class JsonCovidDoc
    {
        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; } = "";

        [JsonPropertyName("data")]
        public List<JsonCovidItem> Data { get; set; } = new List<JsonCovidItem>();
    }
}
