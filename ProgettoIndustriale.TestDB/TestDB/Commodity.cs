using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    internal class Commodity
    {
        public static dom.Commodity data() 
        { 
            return new dom.Commodity() 
            { 
                Id = 1, 
                Name = "Brent",
                ValueUsd=76.48, 
                Unit="$/Barile",
                IdDates=1
            }; 
        }
        
    }
}
