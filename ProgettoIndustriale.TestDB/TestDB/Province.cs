using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    internal class Province
    {
        public dom.Province data() 
        { 
            return new dom.Province() 
            { 
                Id = 1, 
                Name = "Rome", 
                Longitude= "12.4963655", 
                Latitude= "41.9027835" , 
                Surface=1.285f ,
                Altitude=21, 
                Residents=2873,
                PopulationDensity=2235,
                NCities=121, 
                IdRegion=1
            }; 
        }
        
    }
}
