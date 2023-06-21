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
            var db = DatabaseProva.Context();
            db.Add(Data());
            db.SaveChanges();
        }
    }
}
