// See https://aka.ms/new-console-template for more information
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Service.Api;
using ProgettoIndustriale.Data;
using System;
using ProgettoIndustriale.Type;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Aggiungi questo import
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
        Console.WriteLine("Importazione completata per MacroZone.");
        // Importa i dati per la tabella Regions
        dataImportManager.ImportData("region");
        Console.WriteLine("Importazione completata per Region.");
        // Importa i dati per la tabella Provinces
        dataImportManager.ImportData("province");
        Console.WriteLine("Importazione completata per Province.");
        // Importa i dati per la tabella Industry
        dataImportManager.ImportData("industry");
        Console.WriteLine("Importazione completata per Industry.");

        dataImportManager.ImportData("generation");
        Console.WriteLine("Importazione completata per Generation.");

        dataImportManager.ImportData("load");
        Console.WriteLine("Importazione completata per Load.");


        Console.WriteLine("Importazione completata per tutti i CSV.");

    }
}

//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Threading.Tasks;
//using System.IO;
//using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using Microsoft.Extensions.Configuration.Json;
//using ProgettoIndustriale.Business.Imp;
//using ProgettoIndustriale.Business;
//using ProgettoIndustriale.Data;
//using ProgettoIndustriale.Type;

//public class ProgettoIndustrialeJob : IJob
//{
//    public async Task Execute(IJobExecutionContext context)// parametro passato automaticamente da Quartz.NET

//    {
//        var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//            .Build();

//        var connectionString = configuration.GetConnectionString("ProgettoIndustriale");
//        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 3));

//        var options = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
//            .UseMySql(connectionString, serverVersion).Options;

//        var db = new ProgettoIndustrialeContext(options);

//        DataResetManager dataResetManager = new DataResetManager(db, configuration);
//        dataResetManager.ResetData();
//        dataResetManager.ResetAutoIncrement(connectionString!, serverVersion);
//        Console.WriteLine("Reset dei dati completato.");

//        DataImportManager dataImportManager = new DataImportManager(db);
//        // Importa i dati per la tabella MacroZone
//        dataImportManager.ImportData("macrozone");
//        Console.WriteLine("Importazione completata per MacroZone.");
//        // Importa i dati per la tabella Regions
//        dataImportManager.ImportData("region");
//        Console.WriteLine("Importazione completata per Region.");
//        // Importa i dati per la tabella Provinces
//        dataImportManager.ImportData("province");
//        Console.WriteLine("Importazione completata per Province.");
//        // Importa i dati per la tabella Industry
//        dataImportManager.ImportData("industry");
//        Console.WriteLine("Importazione completata per Industry.");

//        dataImportManager.ImportData("generation");
//        Console.WriteLine("Importazione completata per Generation.");

//        dataImportManager.ImportData("load");
//        Console.WriteLine("Importazione completata per Load.");


//        Console.WriteLine("Importazione completata per tutti i CSV.");
//    }
//}

//public class SchedulerTime
//{
//    static async Task Main(string[] args)
//    {
//        // Initialize the scheduler factory
//        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
//        IScheduler scheduler = await schedulerFactory.GetScheduler();

//        // Configure the job
//        var jobDetail = JobBuilder.Create<ProgettoIndustrialeJob>()
//            .WithIdentity("ProgettoIndustrialeJob", "group1")
//            .Build();

//        // Configure the trigger to run the job 
//        ITrigger trigger = TriggerBuilder.Create()
//            .WithIdentity("ProgettoIndustrialeTrigger", "group1")
//            .StartNow()
////            .WithCronSchedule("0 58 14 * * ? *")
//            .Build();


//        // Add the job and trigger to the scheduler
//        await scheduler.ScheduleJob(jobDetail, trigger);

//        // Start the scheduler
//        await scheduler.Start();

//        // Wait for a certain period of time to visualize the execution of the job
//        //await Task.Delay(TimeSpan.FromMinutes(2));

//        // Shutdown the scheduler
//        await scheduler.Shutdown();
//    }
//}





