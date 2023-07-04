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


namespace ProgettoIndustriale.Business.Imp
{
    public class DataResetManager : IDataResetManager
    {
        private readonly ProgettoIndustrialeContext _context;

        public DataResetManager(ProgettoIndustrialeContext context)
        {
            _context = context;
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

                    //// Ripristina l'ID auto-incrementale
                    //string resetSql = $"ALTER TABLE {tableInfo.nometabella} AUTO_INCREMENT = 1";
                    //_context.Database.ExecuteSqlRaw(resetSql);

                }

                _context.SaveChanges();

            }

            ResetAutoIncrement();

        }

        public void ResetAutoIncrement()
        {
            string connectionString = "Server=localhost;Port=3306;Database=progettoindustriale;Uid=RestUser;Pwd=restPassword;";
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ResetAutoIncrement", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.ExecuteNonQuery();
                }
            }
        }

        private List<JsonAnagrafe> LoadTableInfos()
        {
            string jsonContent = System.IO.File.ReadAllText(@"C:\Users\user\ITS-ICT-ProgettoIndustriale\ProgettoIndustriale.Service.Api\Properties\JsonAnagrafe\JsonAnagrafe.json");

            List<JsonAnagrafe> tableInfos = JsonConvert.DeserializeObject<List<JsonAnagrafe>>(jsonContent);

            //tableInfos.Reverse(); // Inverte l'ordine degli elementi nella lista

            return tableInfos;
        }
    }
}
