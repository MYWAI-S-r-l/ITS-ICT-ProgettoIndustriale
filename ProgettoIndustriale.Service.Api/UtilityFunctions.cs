using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;

namespace ProgettoIndustriale.Service.Api
{
    public static class UtilsFunctions
    {


        public static string SubstringController(object s)
        {
            StringBuilder ris = new StringBuilder();
            ris.Append("------");
            ris.Append((s.ToString()!.ToUpper().Split('.').LastOrDefault() ?? "").Substring(0, (s.ToString()!.Split('.').LastOrDefault() ?? "").Length - 10));
            ris.Append(" EXECUTE");
            ris.Append("-------");

            return ris.ToString();
        }

    }



    public class CheckDate
    {
        public static string? errorMessage { get; set; } = "";
       

        private enum Cod
        {
           
            Low = 1,//1
            Medium = 2,//2
            High = 3//3

        }

        public static void ReadFileJson(string k)
        {
            

            try
            {
                var file = File.ReadAllText("properties.json");

                var jsonData = (JObject)JsonConvert.DeserializeObject(file);

                errorMessage = jsonData[k].ToString();


            }
            catch
            {
                errorMessage = "Lettura del file fallita";
            }

           
        }


        public static bool TryDateCheck(DateTime startDate, DateTime endDate)
        {

            
            string errorPrefix = "checkDateErrorMessage_";
            string errorLevel="";
            string errorProperty = "";





            if (startDate > endDate)//1
            {
                errorLevel = ((int)Cod.Low).ToString();
                
            }
            else if (startDate > DateTime.Now)//2
            { 
                errorLevel = ((int)Cod.Medium).ToString();
            }
            else if (startDate == default || endDate == default)//3
            {
                errorLevel = ((int)Cod.High).ToString();
            }
            if(errorLevel=="")
            {
                return true;
            }

            errorProperty = errorPrefix + errorLevel;
            ReadFileJson(errorProperty);

            return false;
        }

    }


        
}
