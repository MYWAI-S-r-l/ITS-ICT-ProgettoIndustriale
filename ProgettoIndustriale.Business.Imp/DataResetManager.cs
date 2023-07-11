using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Newtonsoft.Json;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Type.Domain;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace ProgettoIndustriale.Business.Imp
{
    public class DataResetManager : IDataResetManager
    {
        private readonly ProgettoIndustrialeContext _context;
        private readonly IConfiguration _configuration;

        public DataResetManager(ProgettoIndustrialeContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public void ResetData()
        {
            List<JsonAnagrafe> tableInfos = LoadTableInfos();

            foreach (var tableInfo in tableInfos)
            {
                System.Type? entityType = System.Type.GetType(tableInfo.classe);

                var setMethod = typeof(DbContext)
                    .GetMethods()
                    .FirstOrDefault(m => m.Name == "Set" && m.GetParameters().Length == 0 && m.ReturnType.IsGenericType)
                    ?.MakeGenericMethod(entityType);

                var dbSet = setMethod?.Invoke(_context, null) as dynamic;

                if (dbSet != null)
                {
                    
                    // Cancella tutti i dati dalla tabella
                    dbSet.RemoveRange(dbSet);

                    

                }

                _context.SaveChanges();

            }

            //ResetAutoIncrement();

        }


        public void ResetAutoIncrement(string connectionString, MariaDbServerVersion serverVersion)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "ResetAutoIncrement";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }


        private List<JsonAnagrafe> LoadTableInfos()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties", "JsonAnagrafe", "JsonAnagrafe.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<JsonAnagrafe> tableInfos = JsonConvert.DeserializeObject<List<JsonAnagrafe>>(jsonContent);
            tableInfos.Reverse();
            return tableInfos;
        }
    }
}
