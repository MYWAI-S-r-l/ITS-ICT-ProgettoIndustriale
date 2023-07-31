
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

public class RunCalls : IJob
{
    public async Task Execute(IJobExecutionContext context)
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
            .WithCronSchedule("0 0 12 * * ?") // Espressione cron per farlo eseguire ogni giorno alle 12:00 PM 
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

