using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class ProvinceController
{
    [HttpPost("insertProvinceFromApi")]
    public ActionResult<List<Dto.Provincia>> InsertProvinceFromApi()
    {
      
        string url = "https://axqvoqvbfjpaamphztgd.functions.supabase.co/province";

        var client = new RestClient(url);
        
        // NOTA: se la struttura restituita dal web service esterno
        // fosse diversa dalla classe target Dto.Provincia sarebbe
        // necessario implementare un mapper
        var response = client.Execute<List<Dto.Provincia>>(new RestRequest());

        if (response.Data != null)
        {
            // in prima istanza cancello tutti i record e li reinserisco, 
            // a regime si potrebbe eseguire un controllo e sovrascrivendo
            // quelli esistenti e inserendo quelli nuovi
            _provinceManager.DeleteProvince();
            _provinceManager.SaveProvince(response.Data);

            return response.Data;
        } else
        {
            return new List<Dto.Provincia>();
        }

        
    }
    
}