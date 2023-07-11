// See https://aka.ms/new-console-template for more information
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Service.Api;
using ProgettoIndustriale.Data;
using System;
using ProgettoIndustriale.Type;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Aggiungi questo import
using ProgettoIndustriale.Data;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("ProgettoIndustriale");
        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 3)); // Aggiungi la dichiarazione di serverVersion

        var options = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
            .UseMySql(connectionString, serverVersion).Options;

        var db = new ProgettoIndustrialeContext(options);

        DataResetManager dataResetManager = new DataResetManager(db, configuration);
        dataResetManager.ResetData();
        dataResetManager.ResetAutoIncrement(connectionString, serverVersion);
        Console.WriteLine("Reset dei dati completato.");

        DataImportManager dataImportManager = new DataImportManager(db);
        // Importa i dati per la tabella MacroZone
        dataImportManager.ImportData("macrozone");
        // Importa i dati per la tabella Regions
        dataImportManager.ImportData("region");
        // Importa i dati per la tabella Provinces
        dataImportManager.ImportData("province");
        // Importa i dati per la tabella Industry
        dataImportManager.ImportData("industry");

        Console.WriteLine("Importazione completata.");

    }
}





