using System;
using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;

class Program
{
    static void Main()
    {
        // Connection string for the MariaDB database -- Find how to use the one in API settings
        var connectionString = "Server=localhost;Port=3310;Database=YourDatabaseName;Uid=YourUsername;Pwd=YourPassword;";
        var serverVersion = new MySqlServerVersion(new Version(10, 11, 3)); // Sostituisci con la versione del tuo server MariaDB

        // Create the DbContext using the connection string
        var optionsBuilder = new DbContextOptionsBuilder<ProgettoIndustrialeContext>();
        optionsBuilder.UseMySql(connectionString, serverVersion);

        var dbContext = new ProgettoIndustrialeContext(optionsBuilder.Options);

        // Location of the config file
        var jsonConfigLocation = "path/to/your/config/file.json";

        // Create an instance of ApiManager and pass the DbContext
        var apiManager = new ProgettoIndustriale.Business.Imp.ApiManager(dbContext);

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