using dom=ProgettoIndustriale.Type.Domain;
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

        public static dom.Weather data() { 
            return new dom.Weather ()
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
                IdDate = 1,

            };
        }

        public static void loadDbWeather()
        {
            try
            {

            }catch(Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }

            var db = DatabaseProva.Context();
            db.Add(data());
            db.SaveChanges();
        }
    }
}
