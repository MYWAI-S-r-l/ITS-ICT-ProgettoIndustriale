using System;
using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

class Program
{
    static void Main()
    {

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        //var serverVersion = new MySqlServerVersion(new Version(10, 11, 3)); // Sostituisci con la versione del tuo server MariaDB

        var connectionString = configuration.GetConnectionString("ProgettoIndustriale");

        var options = new DbContextOptionsBuilder<ProgettoIndustrialeContext>()
           .UseMySql(connectionString, new MariaDbServerVersion(new Version (10, 11, 3)))
           .Options;

        var dbContext = new ProgettoIndustrialeContext(options);

        // Create an instance of ApiManager and pass the DbContext
        var apiManager = new ProgettoIndustriale.Business.Imp.ApiManager(dbContext, configuration);

        // Location of the config file
        var jsonConfigLocation = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\apiConfig.json";

        // Process the config file and get the JsonApiConfig object
        var config = apiManager.ProcessConfigFile(jsonConfigLocation);

        if (config != null)
        {
            // Run the API calls
            apiManager.RunCalls(config).GetAwaiter().GetResult();
        }

        // Dispose the DbContext
        dbContext.Dispose();

        Console.WriteLine("API calls completed.");
        Console.ReadLine();
    }
}