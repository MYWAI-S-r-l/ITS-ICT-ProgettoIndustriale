using ProgettoIndustriale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    internal class DataIndustry
    {
        public static dom.Industry data() 
        { 
            return new dom.Industry() 
            { 
                
                Name = "Tim", 
                IdProvince = 1, 
                CountActive=50 
            }; 
        }

        public static void loadDbIndustry(ProgettoIndustrialeContext db)
        {

            try
            {
                
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
