// See https://aka.ms/new-console-template for more information
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Service.Api;
using ProgettoIndustriale.Data;
using System;
using ProgettoIndustriale.Type;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        var contextOptions = new DbContextOptionsBuilder<ProgettoIndustrialeContext>().UseInMemoryDatabase<ProgettoIndustrialeContext>("ProgettoIndustrialeTest").Options;
        var db = new ProgettoIndustrialeContext(contextOptions);

        DataImportManager dataImportManager = new DataImportManager(db);

        // Importa i dati per la tabella MacroZone
        dataImportManager.ImportData("MacroZone");

        // Importa i dati per la tabella Regions
        dataImportManager.ImportData("Regions");

        // Importa i dati per la tabella Provinces
        dataImportManager.ImportData("Provinces");

        // Importa i dati per la tabella Industry
        dataImportManager.ImportData("Industry");

        Console.WriteLine("Importazione completata.");
    }
}


