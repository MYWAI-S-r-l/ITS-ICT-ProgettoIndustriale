﻿using ProgettoIndustriale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public  class DataGeneration
    {
        
        public DataGeneration () { }
        public static dom.Generation data() { 
            return new dom.Generation() 

            { 
                
                GenerationGhw = 274.47, 
                Type="Solar",
                IdDate=1
            }; 
        }

        public static void loadDbGeneration(ProgettoIndustrialeContext db)
        {
            try
            {
                
                db.Add(data());
                db.SaveChanges();
            }
            catch(Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }



            
        }

    }
}
