//// See https://aka.ms/new-console-template for more information
//using ProgettoIndustriale.Business.Imp;
//using ProgettoIndustriale.Business;
//using ProgettoIndustriale.Service.Api;
//using ProgettoIndustriale.Data;
//using System;
//using ProgettoIndustriale.Type;
//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Aggiungi questo import
//using Microsoft.Extensions.Configuration;

//class Program
//{
//    static void Main()
//    {

//        var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//            .AddEnvironmentVariables()
//            .Build();

//        var connectionString = configuration.GetConnectionString("ProgettoIndustriale");
//        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 3)); // Aggiungi la dichiarazione di serverVersion

//        var options = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
//            .UseMySql(connectionString, serverVersion).Options;

//        var db = new ProgettoIndustrialeContext(options);

//        DataResetManager dataResetManager = new DataResetManager(db, configuration);

//        dataResetManager.ResetData();
//        dataResetManager.ResetAutoIncrement(connectionString, serverVersion);
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

using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration.Json;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.HelperDACQ;
//using ProgettoIndustriale.Business;
using ProgettoIndustriale.Data;
using System.Configuration;
//using ProgettoIndustriale.Type;

namespace ProgettoIndustriale.Scheduler;

class Program
{

    private static IConfiguration GetConfig()
    {

        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

        return configuration;
    }

    private static ProgettoIndustrialeContext? GetDbContext(string connectionString, MariaDbServerVersion? serverVersion)
    {
        var options = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
            .UseMySql(connectionString, serverVersion).Options;

        var dbcontext = new ProgettoIndustrialeContext(options);

        return dbcontext;
    }

    private static ApiManager? GetApiManager()
    {
        var configuration = GetConfig();

        var connectionString = configuration.GetConnectionString("ProgettoIndustriale");

        var dbcontext = GetDbContext(connectionString!, serverVersion);

        ApiManager apiManager = new ApiManager(dbcontext, configuration);

        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 3)); // Aggiungi la dichiarazione di serverVersion
        return apiManager;
    }

    public class CSVJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)// parametro passato automaticamente da Quartz.NET

        {
            var configuration = GetConfig();

            var connectionString = configuration.GetConnectionString("ProgettoIndustriale");
            var serverVersion = new MariaDbServerVersion(new Version(10, 11, 3));

            var db = GetDbContext(connectionString!, serverVersion);

            DataResetManager dataResetManager = new DataResetManager(db!, configuration);
            dataResetManager.ResetData();
            dataResetManager.ResetAutoIncrement(connectionString!, serverVersion);
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

    public class DailyJob: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            ApiManager apiManager = GetApiManager();

            var apiConfig = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\dailyApiConfig.json";
            var weatherDailyConfig = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherForecastCallsDemo.json";

            List<string> filepaths = new List<string> { apiConfig, weatherDailyConfig };

            HelperManager helper = new HelperManager(filepaths, apiManager);

            helper.CallsRunner();
        }
    }

    public class HistoryJob: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            ApiManager apiManager = GetApiManager();

            var apiConfig = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\apiConfig.json";
            var weatherHistory2021Demo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2021Demo.json";
            var weatherHistory2022Demo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2022Demo.json";
            var weatherHistory2023Demo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2023Demo.json";
            List<string> filepaths = new List<string> { apiConfig, weatherHistory2023Demo, weatherHistory2022Demo, weatherHistory2021Demo };

            HelperManager helper = new HelperManager(filepaths, apiManager);

            helper.CallsRunner();
        }
    }

    public class SchedulerTime
    {
        static async Task Main(string[] args)
        {
            // Initialize the scheduler factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();

            // Configure the job
            var CSVdetail = JobBuilder.Create<CSVJob>()
                .WithIdentity("CSVJob", "historyGroup")
                .Build();

            // Configure the trigger to run the job 
            ITrigger CSVtrigger = TriggerBuilder.Create()
                .WithIdentity("CSVTrigger", "historyGroup")
                .StartNow()
                .Build();


            // Add the job and trigger to the scheduler
            await scheduler.ScheduleJob(CSVdetail, CSVtrigger);

            var HistoryDetail = JobBuilder.Create<HistoryJob>()
                .WithIdentity("HistoryJob", "historyGroup")
                .Build();

            ITrigger HistoryTrigger = TriggerBuilder.Create()
                .WithIdentity("HistoryTrigger", "historyGroup")
                .StartNow()
                .Build();

            await scheduler.ScheduleJob(HistoryDetail, HistoryTrigger);

            var DailyDetail = JobBuilder.Create<DailyJob>()
                .WithIdentity("DailyJob", "dailyGroup")
                .Build();

            ITrigger DailyTrigger = TriggerBuilder.Create()
                .WithIdentity("DailyTrigger", "dailyGroup").WithDailyTimeIntervalSchedule(x =>
                x.OnEveryDay()
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(1, 0))
                .WithIntervalInHours(4))
                .Build();

            await scheduler.ScheduleJob(DailyDetail, DailyTrigger);


            // Start the scheduler
            await scheduler.Start();

            while (true)
            {
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }

}