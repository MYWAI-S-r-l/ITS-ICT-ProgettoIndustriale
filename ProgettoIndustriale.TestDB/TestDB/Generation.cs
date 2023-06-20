using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public  class Generation
    {
        
        public dom.Generation data() 
        { 
            return new dom.Generation() 
            { 
                Id = 1, 
                GenerationGhw = 274.47, 
                Type="Solar",
                IdDates=1}; 
        }
        
    }
}
