using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom = ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataPrice
    {
        public DataPrice() { }
        public static dom.Price Prices()
        {
            return new dom.Price()
            {
                
                BasePriceEur = 12.22f,
                IncentiveComponentEur = 12.22f,
                UnbalancePriceEur = 10.22f,
                IdDate = 1,
                IdMacroZone = 1
            };
        }

        public static void loadDbPrices(ProgettoIndustrialeContext db)
        {
            try
            {
                //var db = DatabaseProva.Context();
                db.Add(Prices());
                db.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }

           
        }
    }

}


