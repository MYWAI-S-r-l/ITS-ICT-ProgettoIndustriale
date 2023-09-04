using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class Commodity
    {
        public Commodity() { }
        
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("data")]
        public List<CommodityData> CommodityData { get; set; }
        [JsonPropertyName("unit")]
        public string? Unit  { get; set; }
        
        public double ValueUsd { get; set; }
        public Date? Date { get; set; }

    }
}