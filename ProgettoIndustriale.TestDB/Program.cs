using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;

using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.TestDB.TestDB;


Console.WriteLine("Test Database");
Console.WriteLine("\n\n1)Test Commodity\n2)Test Date\n3)Test Generation\n4)Test Industry\n5)Test Load\n6)Test Macrozone\n)" +
    "7)Test Price\nn8)Test Province\n9)Test Region\n10)Weather\n");

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


