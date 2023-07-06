using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class Commodity
    {

        public Commodity() { }
        
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("data")]
        public List<Dictionary<string, string>> Data { get; set; }
        [JsonPropertyName("unit")]
        public string Unit  { get; set; }

    }
}
