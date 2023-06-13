namespace ProgettoIndustriale.Type.Dto;

public class Meteo
{
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GenerationTimeMs { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string? Timezone { get; set; }
        public string? TimezoneAbbreviation { get; set; }
        public double Elevation { get; set; }
        //public HourlyData Hourly { get; set; }
}
