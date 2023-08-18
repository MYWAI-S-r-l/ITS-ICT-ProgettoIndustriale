using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class WeatherData

    {
        public WeatherData() { }
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; }

        [JsonPropertyName("dewpoint_2m")]
        public List<double> Dewpoint { get; set; }

        [JsonPropertyName("relativehumidity_2m")]
        public List<double> RelativeHumidity { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public List<double> ApparentTemperature { get; set; }

        [JsonPropertyName("cloudcover")]
        public List<double> Cloudcover { get; set; }

        [JsonPropertyName("windspeed_10m")]
        public List<double> WindSpeed10m { get; set; }

        [JsonPropertyName("windspeed_80m")]
        public List<double> WindSpeed80m { get; set; }

        [JsonPropertyName("surface_pressure")]
        public List<double> SurfacePressure { get; set; }

        [JsonPropertyName("rain")]
        public List<double> Rain { get; set; }

        [JsonPropertyName("snowfall")]
        public List<double> Snowfall { get; set; }

        [JsonPropertyName("showers")]
        public List<double> Shower { get; set; }

        [JsonPropertyName("snow_depth")]
        public List<double> SnowDepth { get; set; }

        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; }

        [JsonPropertyName("is_day")]
        public List<int> IsDay { get; set; }
    }
}
