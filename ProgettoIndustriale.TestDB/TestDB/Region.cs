﻿using ProgettoIndustriale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dom=ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.TestDB.TestDB
{
    internal class DataRegion
    {
        //dom.Region DataRegions = new dom.Region() { Id = 1, Name = "Lazio", IdMacroZone = 2 };
        public static dom.Region data() 
        { 
            return new dom.Region() 
            {
                
                Name = "Lazio", 
                IdMacroZone = 1
            }; 
        }
        public static void loadDbRegion(ProgettoIndustrialeContext db)
        {
            try
            {
               
                db.Add(data());
                db.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }
            
        }

    }
}
