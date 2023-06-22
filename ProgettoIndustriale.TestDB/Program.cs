using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;

using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.TestDB.TestDB;


Console.WriteLine("Test Database");
Console.WriteLine("\n\n1)Test Macrozone\n2)Test Region\n3)Test Province\n4)Test Industry\n5)Test Date\n6)Test Weather\n)" +
    "7)Test Commodity\nn8)Test Generation\n9)Test Loat\n10)Test Prices\n");

string user = Console.ReadLine();

switch (user)
{
    case "1":
        DataMacrozone.loadDbMacrozone();
        break;
    case "2":
        DataRegion.loadDbRegion();
        break;
    case "3":
        DataProvince.LoadDbProvince();
        break;
    case "4":
        DataIndustry.loadDbIndustry();
        break;
    case "5":
       DataDate.loadDbDate();
        break;
    case "6":
        DataWeather.loadDbWeather();
        break;
    case "7":
        DataCommodity.loadDbCommodity();
        break;
    case "8":
        DataGeneration.loadDbGeneration();
        break;
    case "9":
        DataLoad.loadDbLoad();
        break;
    case "10":
        DataPrice.loadDbPrices();
        break;
    default:
        break;
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");




/*
ProgettoIndustrialeContext context;
var regione = Region.data();
context.Add(regione);
*/


