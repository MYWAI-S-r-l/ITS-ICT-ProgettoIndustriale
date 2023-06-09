﻿using dom=ProgettoIndustriale.Type.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.TestDB.TestDB
{
    public class DataDate
    {

        public DataDate() { }

        public static dom.Date data() { 
            return new dom.Date()

            {
                
                
                DateTime = new DateTime(2023, 6, 19),
                Year = 2023,
                Month = 6,
                Day = 19,
                Hour = 2 
            };
        }

        public static void loadDbDate(ProgettoIndustrialeContext db)
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
