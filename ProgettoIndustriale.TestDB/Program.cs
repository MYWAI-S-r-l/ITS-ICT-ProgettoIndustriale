using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;

using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.TestDB.TestDB;
using ProgettoIndustriale.TestDB;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Test Database");
Console.WriteLine("\n\n1)Test Macrozone\n2)Test Region\n3)Test Province\n4)Test Industry\n5)Test Date\n6)Test Weather\n" +
    "7)Test Commodity\n8)Test Generation\n9)Test Load" +
    "\n10)Test Prices\n");

string user = Console.ReadLine();
var db = DatabaseProva.Context();

switch (user)
{
    case "1":
        DataMacrozone.loadDbMacrozone(db);
        break;
    case "2":
        DataRegion.loadDbRegion(db);
        break;
    case "3":
        DataProvince.LoadDbProvince(db);
        break;
    case "4":
        DataIndustry.loadDbIndustry(db);
        break;
    case "5":
       DataDate.loadDbDate(db);
        break;
    case "6":
        DataWeather.loadDbWeather(db);
        break;
    case "7":
        DataCommodity.loadDbCommodity(db);
        break;
    case "8":
        DataGeneration.loadDbGeneration(db);
        break;
    case "9":
        DataLoad.loadDbLoad(db);
        break;
    case "10":
        DataPrice.loadDbPrices(db);
        break;
    default:
        break;
}


Console.WriteLine("siamo usciti dallo switch!\n");
var tabelle = new List<string>() {"commodity","generation","load","price","industry","weather","date","province","region","macrozone"};

Console.WriteLine("stiamo per iniziare il ciclo di eliminazione dei dati all'interno delle tabelle!");
foreach (var item in tabelle)
{
    Console.WriteLine($"eliminazione di: {item}\n");
    db.Database.ExecuteSql($"truncate table {item};");
}
Console.Write("abbiamo finito di fare il TRUNCATE di tutte le tabelle!! :)");


// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");




/*
ProgettoIndustrialeContext context;
var regione = Region.data();
context.Add(regione);
*/


