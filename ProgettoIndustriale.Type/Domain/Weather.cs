using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public class Weather

    {
        public Weather()
        { }

        [Column("ID_weather")]
        public int Id { get; set; }

        //[Column ("temperature_2_m - °C")] questa è un decoratore per associare il nome alla tab

        [Column("temperature_2m_Celsius")]
        public double Temperature { get; set; }

        [Column("dewpoint_2m_Celsius")]
        public double Dewpoint { get; set; }

        [Column("relative_humidity_2m_percent")]
        public double RelativeHumidity { get; set; }

        [Column("apparent_temperature_Celsius")]
        public double ApparentTemperature { get; set; }

        [Column("cloudcover_percent")]
        public double Cloudcover { get; set; }

        [Column("windspeed_10m_km_h")]
        public double WindSpeed10m { get; set; }

        [Column("windspeed_80m_km_h")]
        public double WindSpeed80m { get; set; }

        [Column("surface_pressure_hPA")]
        public double SurfacePressure { get; set; }

        [Column("rain_mm")]
        public double Rain { get; set; }

        [Column("snowfall_mm")]
        public double Snowfall { get; set; }

        [Column("shower_mm")]
        public double Shower { get; set; }

        [Column("precipitation_mm")]
        public double Precipitation { get; set; }

        [Column("snow_depth_meters")]
        public double SnowDepth { get; set; }

        [Column("is_day_bool")]
        public int IsDay { get; set; }

        [Column("COD_province")]
        public int IdProvince { get; set; }

        [Column("COD_date")]
        public int IdDate { get; set; }

        public virtual Province? Province { get; set; }

        public virtual Date? Date { get; set; }
    }
}