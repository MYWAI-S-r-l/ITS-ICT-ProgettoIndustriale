using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;

using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.TestDB.TestDB;
using ProgettoIndustriale.TestDB;
using Microsoft.EntityFrameworkCore;





bool ciclo = true;
do
{
    var db = DatabaseProva.Context();
    Console.WriteLine("Test Database");
    Console.WriteLine("\n\n1)Test Macrozone\n2)Test Region\n3)Test Province\n4)Test Industry\n5)Test Date\n6)Test Weather\n7)Test Commodity\n8)Test Generation\n9)Test Load\n10)Test Prices\n11)Inserimento Load Macrozone e Date tutte insieme\n12)Inserimento di tutte le tabelle\n13)EXIT");
    string? user = Console.ReadLine();
    switch(user)
    { 
    case "1":
        DataMacrozone.loadDbMacrozone(db);
        Console.WriteLine(  $"Nella tabella ci sono {db.MacroZone.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "2":
        DataRegion.loadDbRegion(db);
        Console.WriteLine($"Nella tabella ci sono {db.Region.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "3":
        DataProvince.LoadDbProvince(db);
        Console.WriteLine($"Nella tabella ci sono {db.Province.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "4":
        DataIndustry.loadDbIndustry(db);
            Console.WriteLine($"Nella tabella ci sono {db.Industry.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "5":
        DataDate.loadDbDate(db);
        Console.WriteLine($"Nella tabella ci sono {db.Date.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "6":
        DataWeather.loadDbWeather(db);
        Console.WriteLine($"Nella tabella ci sono {db.Weather.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "7":
        DataCommodity.loadDbCommodity(db);
        Console.WriteLine($"Nella tabella ci sono {db.Commodity.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "8":
        DataGeneration.loadDbGeneration(db);
        Console.WriteLine($"Nella tabella ci sono {db.Generation.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "9":
        DataLoad.loadDbLoad(db);
        Console.WriteLine($"Nella tabella ci sono {db.Load.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "10":
        DataPrice.loadDbPrices(db);
        Console.WriteLine($"Nella tabella ci sono {db.Price.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "11":
        ClasseGenerale.load(db);
        Console.WriteLine($"Nella tabella ci sono {db.Load.Count()} righe /nTest ok");
        Console.WriteLine($"Nella tabella ci sono {db.Date.Count()} righe /nTest ok");
        Console.WriteLine($"Nella tabella ci sono {db.MacroZone.Count()} righe /nTest ok");
            db.Dispose();
            break;
    case "12":
            DataMacrozone.loadDbMacrozone(db);
            Console.WriteLine($"Nella tabella ci sono {db.MacroZone.Count()} righe /nTest ok");

            DataRegion.loadDbRegion(db);
            Console.WriteLine($"Nella tabella ci sono {db.Region.Count()} righe /nTest ok");

            DataProvince.LoadDbProvince(db);
            Console.WriteLine($"Nella tabella ci sono {db.Province.Count()} righe /nTest ok");

            DataIndustry.loadDbIndustry(db);
            Console.WriteLine($"Nella tabella ci sono {db.Industry.Count()} righe /nTest ok");

            DataDate.loadDbDate(db);
            Console.WriteLine($"Nella tabella ci sono {db.Date.Count()} righe /nTest ok");

            DataWeather.loadDbWeather(db);
            Console.WriteLine($"Nella tabella ci sono {db.Weather.Count()} righe /nTest ok");

            DataCommodity.loadDbCommodity(db);
            Console.WriteLine($"Nella tabella ci sono {db.Commodity.Count()} righe /nTest ok");

            DataGeneration.loadDbGeneration(db);
            Console.WriteLine($"Nella tabella ci sono {db.Generation.Count()} righe /nTest ok");

            DataLoad.loadDbLoad(db);
            Console.WriteLine($"Nella tabella ci sono {db.Load.Count()} righe /nTest ok");

            DataPrice.loadDbPrices(db);
            Console.WriteLine($"Nella tabella ci sono {db.Price.Count()} righe /nTest ok");
            db.Dispose();
            
            

            break;
    case "13":
    	ciclo=false;
        break;
    default:
        break;
}
} while (ciclo);


