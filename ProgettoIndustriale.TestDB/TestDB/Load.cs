using ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataLoad
    {
        public DataLoad() { }
        public Load Load() {
            return new Load()
            {
                Id = 1,
                TotalLoadMW = 10,
                ForecastTotalLoadMw = 11.2f,
                IdDate = 1,
                IdMacroZone = 1

            }; 
        }
    }
}
