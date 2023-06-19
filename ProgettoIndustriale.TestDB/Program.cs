using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Business;
using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.TestDB.TestDB;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ProgettoIndustrialeContext context;
var regione = Region.data();
context.Add(regione);
