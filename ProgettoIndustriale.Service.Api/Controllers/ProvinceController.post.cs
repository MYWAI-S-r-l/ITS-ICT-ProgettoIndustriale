using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;
/*
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
        }
        else
        {
            return new List<Dto.Provincia>();
        }


    }

    //[HttpPost("getMeteoForProvincia")]
    //public ActionResult<Dto.Meteo> InsertProvinceFromApi(Dto.Provincia provincia)
    //{

        var urlGeocoding =
            $"https://geocoding-api.open-meteo.com/v1/search?name={provincia.Nome}&count=10&language=it&format=json";
        var clientGeocoding = new RestClient(urlGeocoding);
        var responseGeocoding = clientGeocoding.Execute(new RestRequest());
        //check that response is ok and deserialize
        /*
        var locationList = Newtonsoft.Json.JsonConvert
            .DeserializeObject<Dto.GeoCodingResponse>(responseGeocoding.Content).Results;
        

        
        var wantedLocation = locationList.FirstOrDefault(x => x.Admin1 == provincia.Regione);
        if (wantedLocation == null) return new Dto.Meteo();

    //    var urlMeteo =
    //        $"https://api.open-meteo.com/v1/forecast?latitude={wantedLocation.Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={wantedLocation.Longitude.ToString(CultureInfo.InvariantCulture)}&hourly=temperature_2m";
    //    var clientMeteo = new RestClient(urlMeteo);
    //    var responseMeteo = clientMeteo.Execute(new RestRequest());
    //    //check that response is ok and deserialize
    //    var meteo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dto.Meteo>(responseMeteo.Content);
    //    return meteo;

    }
}

*/
