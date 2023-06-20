using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business
{
    public class DataImportManager : IDataImportManager
    {
        private static readonly string jsonFilePath = "path/to/json/file.json";

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

            // Do something with the domainObjects list (e.g., save it to a database)
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
            string jsonContent = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<JsonAnagrafe>>(jsonContent);
        }
    }
}

