using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Data;


namespace ProgettoIndustriale.TestDB
{
    public class DatabaseProva
    {
       
        public DatabaseProva() { }
        public static ProgettoIndustrialeContext Context()
        {
            var contextOptions = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
            //.UseMySql(@"Server=localhost; Port=3306; Database=progettoindustrialeTest; Uid=test;"
            .UseMySql(@"Server=localhost; Port=3306;Database=progettoindustriale;Uid=RestUser;Pwd=restPassword;"
            , new MariaDbServerVersion(new Version(10, 11, 2))).Options;


            
            //var contextOptions = new DbContextOptionsBuilder<ProgettoIndustrialeContext>().UseInMemoryDatabase<ProgettoIndustrialeContext>("ProgettoIndustrialeTest")
            //.Options;
            
            return new ProgettoIndustrialeContext(contextOptions);
        }

        


        

    }
}
