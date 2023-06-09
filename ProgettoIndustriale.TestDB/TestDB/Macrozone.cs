﻿using dom = ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataMacrozone
    {
       
        public DataMacrozone() { }
        public static dom.MacroZone Data() { 
            return new dom.MacroZone() 
            { 
                 
                Name = "Nord", 
                BiddingZone = "Nord-Est",
            
            }; 
        }

        public static void loadDbMacrozone(ProgettoIndustrialeContext db)
        {
            try
            {
                
                db.Add(Data());
                db.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("errore durante l'inserimento dei dati");
            }

           
        }
        
        
        
    }
}
