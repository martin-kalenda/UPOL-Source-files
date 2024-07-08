using System.Text.Json.Serialization;

namespace _204
{
    public class JsonCovidItem
    {
        [JsonPropertyName("datum")]
        public DateTime Date { get; set; }

        [JsonPropertyName("prirustkovy_pocet_nakazenych")]
        public int InfectedIncremental { get; set; }

        [JsonPropertyName("kumulativni_pocet_nakazenych")]
        public int InfectedCumulative { get; set; }
    }
}
