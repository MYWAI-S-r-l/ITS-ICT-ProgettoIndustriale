// See https://aka.ms/new-console-template for more information
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Service.Api;
using ProgettoIndustriale.Data;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Inserisci il nome della tabella:");
        string tableName = Console.ReadLine();

        DataImportManager dataImportManager = new DataImportManager();

        dataImportManager.ImportData(tableName);

        Console.WriteLine("Importazione completata.");
    }
}

