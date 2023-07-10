using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class CommodityData
    {

        public CommodityData() { }
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }

    }
}
