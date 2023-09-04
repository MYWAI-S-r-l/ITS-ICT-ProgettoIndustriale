using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class GenerationData
    {

        public GenerationData() { }
        [JsonPropertyName("Date")]
        public string? Date { get; set; }
        [JsonPropertyName("Actual_Generation_GWh")]
        public string? Generation_gwh { get; set; }
        [JsonPropertyName("Primary_Source")]
        public string? Type { get; set; }
    }
}
