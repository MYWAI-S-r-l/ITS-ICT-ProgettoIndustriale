/*
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

//da cambiare con la funzione fatta da Federico
public class RunCalls : IJob
{
    public async Task Execute(IJobExecutionContext context)// parametro passato automaticamente da Quartz.NET
    {
        // Inserisci qui la logica per effettuare le chiamate API o altre attività pianificate
        // Questo metodo verrà eseguito ogni volta che il trigger pianifica il job
        Console.WriteLine("Esecuzione delle chiamate API o delle attività pianificate...");
        await Task.Delay(1000); // Simulazione di un'attività di un secondo
        Console.WriteLine("Chiamate API o attività pianificate completate.");
    }
}

    public class Program
{
    static async Task Main(string[] args)
    {
        // Inizializza il factory e lo scheduler
        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        IScheduler scheduler = await schedulerFactory.GetScheduler();

        // Configurazione del job
        var jobDetail = JobBuilder.Create<RunCalls>()
            .WithIdentity("RunCallsJob", "group1")
            .Build();

        // Configurazione del trigger schedulato, un CronTrigger per eseguire la funzione ogni giorno alle 12:00 PM
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("RunCallsTrigger", "group1")
            .StartNow()// Avvia immediatamente
            .WithCronSchedule("0 0 12 * * ?") // Espressione cron per farlo eseguire ogni giorno alle 12
            .Build();
       
        // Aggiungi il job e il trigger al scheduler (Pianifica il lavoro con il trigger)
        await scheduler.ScheduleJob(jobDetail, trigger);
              
        // Avvia il scheduler
        await scheduler.Start();

        // Aspetta per un certo periodo di tempo per visualizzare l'esecuzione del lavoro
        await Task.Delay(TimeSpan.FromMinutes(5));

        // Interrompi il scheduler
        await scheduler.Shutdown();
    }
}

*/

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
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;

public class ProgettoIndustrialeJob : IJob
{
    public async Task Execute(IJobExecutionContext context)// parametro passato automaticamente da Quartz.NET
    
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("ProgettoIndustriale");
        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 3));

        var options = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
            .UseMySql(connectionString, serverVersion).Options;

        var db = new ProgettoIndustrialeContext(options);

        DataResetManager dataResetManager = new DataResetManager(db, configuration);
        dataResetManager.ResetData();
        dataResetManager.ResetAutoIncrement(connectionString, serverVersion);
        Console.WriteLine("Reset dei dati completato.");

        DataImportManager dataImportManager = new DataImportManager(db);
        dataImportManager.ImportData("macrozone");
        dataImportManager.ImportData("region");
        dataImportManager.ImportData("province");
        dataImportManager.ImportData("industry");

        Console.WriteLine("Importazione completata.");
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
        var jobDetail = JobBuilder.Create<ProgettoIndustrialeJob>()
            .WithIdentity("ProgettoIndustrialeJob", "group1")
            .Build();
        
        // Configure the trigger to run the job 
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("ProgettoIndustrialeTrigger", "group1")
            .StartNow()
            .WithCronSchedule("0 0 12 * * ? *") 
            .Build();
        

        // Add the job and trigger to the scheduler
        await scheduler.ScheduleJob(jobDetail, trigger);

        // Start the scheduler
        await scheduler.Start();

        // Wait for a certain period of time to visualize the execution of the job
        await Task.Delay(TimeSpan.FromMinutes(5));

        // Shutdown the scheduler
        await scheduler.Shutdown();
    }
}