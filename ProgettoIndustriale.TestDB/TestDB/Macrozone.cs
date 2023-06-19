using ProgettoIndustriale.Type.Domain;
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
        public static MacroZone Data() { 
            return new MacroZone() 
            { 
                Id = 1, 
                Name = "Nord", 
                BiddingZone = "Nord-Est",
            
            }; 
        } 
    }
}
