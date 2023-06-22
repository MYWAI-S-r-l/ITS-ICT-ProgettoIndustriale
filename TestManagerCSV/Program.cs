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
        Console.WriteLine("Inserisci il nome della tabella:");
        string tableName = Console.ReadLine();

        var contextOptions = new DbContextOptionsBuilder<ProgettoIndustrialeContext>().UseInMemoryDatabase<ProgettoIndustrialeContext>("ProgettoIndustrialeTest").Options;
        var db = new ProgettoIndustrialeContext(contextOptions);

        DataImportManager dataImportManager = new DataImportManager(db);

        dataImportManager.ImportData(tableName);

        Console.WriteLine("Importazione completata.");
    }
}

