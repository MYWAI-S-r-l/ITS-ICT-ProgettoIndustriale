using dom = ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataLoad
    {
        public DataLoad() { }
        public static dom.Load Data() {
            return new dom.Load()
            {
                Id = 1,
                TotalLoadMW = 10,
                ForecastTotalLoadMw = 11.2f,
                IdDate = 1,
                IdMacroZone = 1

            }; 
        }
        public static void loadDbLoad(ProgettoIndustrialeContext db)
        {

            try
            {
                db.Add(Data());
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }
            
        }
    }
}
