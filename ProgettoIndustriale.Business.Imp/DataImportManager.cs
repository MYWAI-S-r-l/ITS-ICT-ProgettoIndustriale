using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Type;
using System.Text;
using ProgettoIndustriale.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProgettoIndustriale.Business.Imp
{
    public class DataImportManager : IDataImportManager
    {
        //private static readonly string jsonFilePath = @"C:\Users\user\ITS-ICT-ProgettoIndustriale\ProgettoIndustriale.Service.Api\Properties\JsonAnagrafe\JsonAnagrafe.json";
        private static readonly string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties", "JsonAnagrafe", "JsonAnagrafe.json");

        private readonly ProgettoIndustrialeContext _context;
        
        public DataImportManager(ProgettoIndustrialeContext context)
        {
            _context = context;
        }



        public void ImportData(string tableName)
        {
            List<JsonAnagrafe> tableInfos = LoadTableInfos();

            JsonAnagrafe tableInfo = tableInfos.Find(info => info.nometabella == tableName);
            if (tableInfo == null)
            {
                Console.WriteLine("Table name not found in the JSON configuration.");
                return;
            }

            if (string.IsNullOrEmpty(tableInfo.percorso))
            {
                Console.WriteLine($"CSV file path not specified for table: {tableInfo.nometabella}");
                return;
            }

            string csvFilePath = tableInfo.percorso;
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine($"CSV file not found for table: {tableInfo.nometabella}");
                return;
            }

            string[] csvLines = File.ReadAllLines(csvFilePath);
            if (csvLines.Length <= 1)
            {
                Console.WriteLine($"No data found in the CSV file for table: {tableInfo.nometabella}");
                return;
            }

            List<object> domainObjects = new List<object>();

            string[] propertyNames = csvLines[0].Split(',');

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] propertyValues = csvLines[i].Split(',');
                object domainObject = Activator.CreateInstance(System.Type.GetType(tableInfo.classe));
                for (int j = 0; j < propertyNames.Length; j++)
                {
                    string propertyName = propertyNames[j];
                    string propertyValue = propertyValues[j];

                    SetProperty(domainObject, propertyName, propertyValue);
                }

                domainObjects.Add(domainObject);
            }

            // Salva gli oggetti di dominio nel database

            _context.AddRange(domainObjects);
            _context.SaveChanges();

        }

        private void SetProperty(object obj, string propertyName, string propertyValue)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null)
            {
                object convertedValue = Convert.ChangeType(propertyValue, property.PropertyType);
                property.SetValue(obj, convertedValue);
            }
        }

        private List<JsonAnagrafe> LoadTableInfos()
        {
            string jsonContent = File.ReadAllText(jsonFilePath, encoding: Encoding.UTF8);
            return JsonConvert.DeserializeObject<List<JsonAnagrafe>>(jsonContent);
        }
    }
}

