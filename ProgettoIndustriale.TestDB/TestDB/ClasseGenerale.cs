using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class ClasseGenerale
    {
        public ClasseGenerale() { }
        public static void load( ProgettoIndustrialeContext db )
        {
            try
            {
                var l = new Load() { Id = 1, IdMacroZone = 1, MacroZone = DataMacrozone.Data(), Date = DataDate.data(), ForecastTotalLoadMw = 11.2f, IdDate = 1, TotalLoadMW = 10 };
                db.Add(l);
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }

        }
    }
}
