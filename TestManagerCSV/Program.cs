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

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Port=3306;Database=progettoindustriale;Uid=RestUser;Pwd=restPassword;";
        var serverVersion = new MySqlServerVersion(new Version(10, 11, 2)); // Sostituisci con la versione del tuo server MariaDB

        var optionsBuilder = new DbContextOptionsBuilder<ProgettoIndustrialeContext>();
        optionsBuilder.UseMySql(connectionString, serverVersion); // Utilizza la connessione a MariaDB specificando la versione del server

        var db = new ProgettoIndustrialeContext(optionsBuilder.Options);

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





