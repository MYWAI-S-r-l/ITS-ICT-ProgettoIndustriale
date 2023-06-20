
using ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataWeather
    {

        public DataWeather() { }

        public static Weather Data() { 
            return new Weather ()
            {
                Id = 1,
                Temperature = 20,
                Dewpoint = 25,
                RelativeHumidity = 55,
                ApparentTemperature = 24,
                Cloudcover = 44,
                WindSpeed10m = 30,
                WindSpeed80m = 78,
                SurfacePressure = 40,
                Rain = 10,
                Snowfall = 0,
                Shower = 11,
                Precipitation = 12,
                SnowDepth = 0,
                IsDay = 1,
                IdProvince = 1,
                IdDates = 1,

            };
        }
    }
}
