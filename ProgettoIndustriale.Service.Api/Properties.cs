using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Text;

namespace ProgettoIndustriale.Service.Api
{

    /*****************************************************************************************
     * 
     *      RIFAI QUESTO COME JSON --> chiavi tutte uguali e value diversi tra le lingue
     *      
     *      ??   -->    vedi come bisogna incorporare questo file e le sue variabili 
     *                  ai vari valori dell'enum in UtilityFunctions
     *                  (la connesione tra le due cose)
     * 
     *****************************************************************************************/
    public class IT
    {
        public string checkDateErrorMessage_1  {get; set;} = "La data di inizio non può essere successiva alla data di fine";
        public string checkDateErrorMessage_2 { get; set; } = "La data di inizio non può essere futura";
        public string checkDateErrorMessage_3 { get; set; } = "Inserire data";

    }

        
}
