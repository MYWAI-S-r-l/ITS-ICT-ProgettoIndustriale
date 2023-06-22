using ProgettoIndustriale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    internal class DataCommodity
    {
        public static dom.Commodity data() 
        { 
            return new dom.Commodity() 
            { 
                Id = 1, 
                Name = "Brent",
                ValueUsd=76.48, 
                Unit="$/Barile",
                IdDate=1,
            }; 
        }
        public static void loadDbCommodity(ProgettoIndustrialeContext db)
        {

            try
            {
                var db = DatabaseProva.Context();
                db.Add(data());
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }

           
        }

    }
}
