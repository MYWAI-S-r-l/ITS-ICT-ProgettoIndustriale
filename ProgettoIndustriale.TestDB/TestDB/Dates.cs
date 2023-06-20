using ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataDates
    {

        public DataDates() { }

        public static Dates Data() { 
            return new Dates()

            {
                Id = 1,
                DateTime = new DateTime(2023, 6, 19),
                Year = 2023,
                Month = 6,
                Day = 19,
                Time = new DateTime(2023, 2, 10) 
            };
        }
    }
}
