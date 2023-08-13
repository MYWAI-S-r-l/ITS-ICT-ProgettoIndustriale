using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class LoadData
    {
        public LoadData() { }
        [JsonPropertyName("Date")]
        public string Date { get; set; }
        [JsonPropertyName("Total_Load_MW")]
        public string TotalLoadMW { get; set; }
        [JsonPropertyName("Forecast_Total_Load_MW")]
        public string ForecastTotalLoadMw { get; set; }
        [JsonPropertyName("Bidding_Zone")]
        public string BiddingZone { get; set; }

    }
}