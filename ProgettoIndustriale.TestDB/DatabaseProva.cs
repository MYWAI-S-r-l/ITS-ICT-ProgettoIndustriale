using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.TestDB
{
    public class DatabaseProva
    {
        

        public static ProgettoIndustrialeContext Context()
        {
            var contextOptions = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
            .Options;
            return new ProgettoIndustrialeContext(contextOptions);
        }
        

        

    }
}
