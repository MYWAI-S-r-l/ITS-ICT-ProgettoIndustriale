using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;

using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.TestDB.TestDB;
using ProgettoIndustriale.TestDB;
using Microsoft.EntityFrameworkCore;



string user = Console.ReadLine();
var db = DatabaseProva.Context();
bool ciclo = true;
do
{
    Console.WriteLine("Test Database");
    Console.WriteLine("\n\n1)Test Macrozone\n2)Test Region\n3)Test Province\n4)Test Industry\n5)Test Date\n6)Test Weather\n" +
        "7)Test Commodity\n8)Test Generation\n9)Test Load" +
        "\n10)Test Prices\n11)Inserimento Load Macrozone e Date tutte insieme\n12)EXIT");
    case "1":
        DataMacrozone.loadDbMacrozone(db);
            Console.WriteLine(  $"Nella tabella ci sono {db.MacroZone.Count()} righe /nTest ok");
        break;
    case "2":
        DataRegion.loadDbRegion(db);
        Console.WriteLine($"Nella tabella ci sono {db.Region.Count()} righe /nTest ok");
        break;
    case "3":
        DataProvince.LoadDbProvince(db);
        Console.WriteLine($"Nella tabella ci sono {db.Province.Count()} righe /nTest ok");
        break;
    case "4":
        DataIndustry.loadDbIndustry(db);
        Console.WriteLine($"Nella tabella ci sono {db.Industry.Count()} righe /nTest ok");
        break;
    case "5":
       DataDate.loadDbDate(db);
        Console.WriteLine($"Nella tabella ci sono {db.Date.Count()} righe /nTest ok");
        break;
    case "6":
        DataWeather.loadDbWeather(db);
        Console.WriteLine($"Nella tabella ci sono {db.Weather.Count()} righe /nTest ok");
        break;
    case "7":
        DataCommodity.loadDbCommodity(db);
        Console.WriteLine($"Nella tabella ci sono {db.Commodity.Count()} righe /nTest ok");
        break;
    case "8":
        DataGeneration.loadDbGeneration(db);
        Console.WriteLine($"Nella tabella ci sono {db.Generation.Count()} righe /nTest ok");
        break;
    case "9":
        DataLoad.loadDbLoad(db);
        Console.WriteLine($"Nella tabella ci sono {db.Load.Count()} righe /nTest ok");
        break;
    case "10":
        DataPrice.loadDbPrices(db);
        Console.WriteLine($"Nella tabella ci sono {db.Price.Count()} righe /nTest ok");
        break;
    case "11":
        ClasseGenerale.load(db);
        Console.WriteLine($"Nella tabella ci sono {db.Load.Count()} righe /nTest ok");
        Console.WriteLine($"Nella tabella ci sono {db.Date.Count()} righe /nTest ok");
        Console.WriteLine($"Nella tabella ci sono {db.MacroZone.Count()} righe /nTest ok");
       
        break;
    case "12":
    	ciclo=false;
        break;
    default:
        break;
}
} while (ciclo == true);

/*
Console.WriteLine("siamo usciti dallo switch!\n");
var tabelle = new List<string>() {"commodity","generation","load","price","industry","weather","date","province","region","macrozone"};

Console.WriteLine("stiamo per iniziare il ciclo di eliminazione dei dati all'interno delle tabelle!");
foreach (var item in tabelle)
{
    Console.WriteLine($"eliminazione di: {item}\n");
    db.Database.ExecuteSql($"truncate table {item};");
}
Console.Write("abbiamo finito di fare il TRUNCATE di tutte le tabelle!!");
*/

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");




/*
ProgettoIndustrialeContext context;
var regione = Region.data();
context.Add(regione);
*/


