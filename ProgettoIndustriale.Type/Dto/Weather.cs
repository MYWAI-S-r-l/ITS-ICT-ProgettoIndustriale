namespace ProgettoIndustriale.Type.Dto
{
    public class Weather

    {
        public Weather() { }
        public int Id { get; set; }
        //[Column ("temperature_2_m - °C")] questa è un decoratore per associare il nome alla tab
        public double Temperature { get; set; }

        public double Dewpoint { get; set; }

        public double RelativeHumidity { get; set; }

        public double ApparentTemperature { get; set; }

        public double Cloudcover { get; set; }

        public double WindSpeed10m { get; set; }

        public double WindSpeed80m { get; set; }

        public double SurfacePressure { get; set; }

        public double Rain { get; set; }

        public double Snowfall { get; set; }

        public double Showers { get; set; }

        public double Precipitation { get; set; }

        public double SnowDepth { get; set; }
        public int IsDay { get; set; }

        public int IdProvince { get; set; }

        public int IdDates { get; set; }

        public virtual Province Province { get; set; }   

        public virtual Dates Dates { get; set; }

    }
}
