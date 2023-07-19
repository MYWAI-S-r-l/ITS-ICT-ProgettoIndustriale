
using Quartz;
using Quartz.Impl;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        // Inizializza il scheduler Quartz.NET
        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        IScheduler scheduler = await schedulerFactory.GetScheduler();

        // Funzione
        IJobDetail job = JobBuilder.Create<MyJob>()
            .WithIdentity("myJob", "group1")
            .Build();

        // Crea un CronTrigger per eseguire la funzione ogni giorno alle 12:00 PM
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("myTrigger", "group1")
            .StartNow()
            .WithCronSchedule("0 0 12 * * ?") // Espressione cron per ogni giorno alle 12:00 PM si esegue
            .Build();

        // Pianifica il lavoro con il trigger
        await scheduler.ScheduleJob(job, trigger);

        // Avvia il scheduler
        await scheduler.Start();

        // Aspetta per un certo periodo di tempo per visualizzare l'esecuzione del lavoro
        await Task.Delay(TimeSpan.FromMinutes(5));

        // Interrompi il scheduler
        await scheduler.Shutdown();
    }
}

public class MyJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        // Esegui la funzione 
        RunCalls();

        return Task.CompletedTask;
    }

    private void RunCalls()
    {
        // Logica della funzione
        Console.WriteLine("Esecuzione della mia funzione...");

        // Chiamate a metodi o altre operazioni personalizzate
        // ...
    }
}