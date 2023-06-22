using dom=ProgettoIndustriale.Type.Domain;
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

        public static dom.Date data() { 
            return new dom.Date()

            {
                
                Id = 1,
                DateTime = new DateTime(2023, 6, 19),
                Year = 2023,
                Month = 6,
                Day = 19,
                Time = new DateTime(2023, 2, 10) 
            };
        }

        public static void loadDbDate()
        {
            var db = DatabaseProva.Context();
            db.Add(data());
            db.SaveChanges();
        }
    }
}
