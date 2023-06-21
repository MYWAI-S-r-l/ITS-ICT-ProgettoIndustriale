using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    internal class DataIndustry
    {
        public static dom.Industry data() 
        { 
            return new dom.Industry() 
            { 
                Id = 1, 
                Name = "Tim", 
                IdProvince = 1, 
                CountActive=50 
            }; 
        }

        public static void loadDbIndustry()
        {
            var db = DatabaseProva.Context();
            db.Add(data());
            db.SaveChanges();
        }

    }
}
