using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Text;

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



    public static class CheckDate
    {
        public static string errorMessage { get; set; } = "";
        /*
        private enum Cod
        {
            None = 0,//0
            Low = 1,//1
            Medium = 2,//2
            High = 3//3

        }
        
        Dictionary dateMessageErrorCod = new Dictionary<int, string>()
        {
            { 1, "La data di inizio non può essere successiva alla data di fine" },
            { 2, "La data di inizio non può essere futura." },
            { 3, "Inserire data" },
            { 0, "true" }
        };
        */

        public static bool TryDateCheck(DateTime startDate, DateTime endDate)
        {
            
            //var c = Cod.None;
            //errorMessage = Cod.Low.ToString();
            
            if (startDate > endDate)
            {
                errorMessage = "La data di inizio non può essere successiva alla data di fine";
                return false;
            }
            if (startDate > DateTime.Now)
            {
                errorMessage = "La data di inizio non può essere futura.";
                return false;
            }
            if (startDate == default || endDate == default)
            {
                errorMessage = "Inserire data";
                return false;
            }
            return true;
        }

    }
            /*
            public static bool TryDateCheck(DateTime startDate, DateTime endDate, out string errorMessage)
            {

                errorMessage = "";
                if (startDate > endDate)
                {
                    errorMessage = "La data di inizio non può essere successiva alla data di fine";
                    return false;
                }

                if (startDate > DateTime.Now)
                {
                    errorMessage = "La data di inizio non può essere futura.";
                    return false;
                }
                if (startDate == default || endDate == default)
                {
                    errorMessage = "Inserire data";
                    return false;
                }


                return true;
            }
            */



        
}
