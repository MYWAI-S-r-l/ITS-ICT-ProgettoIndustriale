using dom = ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataMacrozone
    {
       
        public DataMacrozone() { }
        public static dom.MacroZone Data() { 
            return new dom.MacroZone() 
            { 
                Id = 1, 
                Name = "Nord", 
                BiddingZone = "Nord-Est",
            
            }; 
        }

        public static void loadDbMacrozone()
        {
            try
            {
                var db = DatabaseProva.Context();
                db.Add(Data());
                db.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }

           
        }
        /*
        public static void removeDbMacrozone()
        {
            var db = DatabaseProva.Context();
            Context.DatabaseProva.ExecuteSqlRaw("Truncate table Macrozone");
            db.SaveChanges();

        }
        */
    }
}
