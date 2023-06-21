using ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataDate
    {

        public DataDate() { }

        public static Date Data() { 
            return new Date()

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
