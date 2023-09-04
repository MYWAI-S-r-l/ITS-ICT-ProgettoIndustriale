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
        var dailyApiConfig = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\dailyApiConfig.json";
        var historyApiConfig = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\apiConfig.json";
        //var weatherHistory2021 = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2021.json";
        //var weatherHistory2022 = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2022.json";
        //var weatherHistory2023 = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2023.json";
        //var weatherForecastConfig = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherForecastCalls.json";

        //var weatherHistory2021Demo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2021Demo.json";
        //var weatherHistory2022Demo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2022Demo.json";
        var weatherHistory2023Demo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherHistoryCalls2023Demo.json";
        var weatherForecastConfigDemo = @"..\..\..\..\ProgettoIndustriale.Service.Api\Properties\configs\weatherForecastCallsDemo.json";

        //List<string> pathList = new List<string> { apiConfig, weatherForecastConfig, weatherHistory2021, weatherHistory2022, weatherHistory2023};
        List<string> pathList = new List<string> { dailyApiConfig, historyApiConfig, weatherHistory2023Demo, weatherForecastConfigDemo };

        foreach (var path in pathList)
        {
            var config = apiManager.ProcessConfigFile(path);

            if (config != null)
            {
                // Run the API calls
                apiManager.RunCalls(config).GetAwaiter().GetResult();
            }
        }

        // Dispose the DbContext
        dbContext.Dispose();

        Console.WriteLine("API calls completed.");
        Console.ReadLine();
    }
}