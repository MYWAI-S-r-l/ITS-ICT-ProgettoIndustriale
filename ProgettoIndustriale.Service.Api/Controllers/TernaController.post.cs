using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Globalization;
using System.Xml;
using Dto = ProgettoIndustriale.Type.Dto;
using Newtonsoft.Json;

namespace ProgettoIndustriale.Service.Api.Controllers;

public class TernaTokenConfig
{
    public string client_id { get; set; } = "k48jhcjhyku2th7t3pg9y2be";
    public string client_secret { get; set; } = "g9khnFNRr8";
    public string grant_type { get; set; } = "client_credentials";
    public string content_type { get; set; } = "application/x-www-form-urlencoded";
}
public partial class TernaController
{
    private const string ternaUrl = "https://api.terna.it";

    [HttpPost("updateToken")]
    public async Task<ActionResult<Dto.TernaToken>> UpdateToken() 
    {
        var config = new TernaTokenConfig();
        var options = new RestClientOptions(ternaUrl)
        {
            MaxTimeout = -1,
        };
        var clientTerna = new RestClient(options);
        var request = new RestRequest("/transparency/oauth/accessToken", Method.Post);

        request.AddHeader("Content-Type", config.content_type);
        request.AddParameter("client_id", config.client_id, ParameterType.GetOrPost);
        request.AddParameter("client_secret", config.client_secret, ParameterType.GetOrPost);
        request.AddParameter("grant_type", config.grant_type, ParameterType.GetOrPost);

        var responseToken = await clientTerna.ExecuteAsync(request);
        string responseContent = responseToken.Content;
        Console.WriteLine(responseContent);

        var token = System.Text.Json.JsonSerializer.Deserialize<Dto.TernaToken>(responseContent);
        //var token = JsonConvert.DeserializeObject<Dto.TernaToken>(responseContent);
        if (token.AccessToken == null) return new Dto.TernaToken();
        token.AddedTime = DateTime.Now;
        
        _ternaManager.UpdateToken(token);
        
        return token;
    }
}

//public partial class ProvinceController
//{
//    [HttpPost("insertProvinceFromApi")]
//    public ActionResult<List<Dto.Provincia>> InsertProvinceFromApi()
//    {

//        string url = "https://axqvoqvbfjpaamphztgd.functions.supabase.co/province";

//        var client = new RestClient(url);

//        // NOTA: se la struttura restituita dal web service esterno
//        // fosse diversa dalla classe target Dto.Provincia sarebbe
//        // necessario implementare un mapper
//        var response = client.Execute<List<Dto.Provincia>>(new RestRequest());

//        if (response.Data != null)
//        {
//            // in prima istanza cancello tutti i record e li reinserisco, 
//            // a regime si potrebbe eseguire un controllo e sovrascrivendo
//            // quelli esistenti e inserendo quelli nuovi
//            _provinceManager.DeleteProvince();
//            _provinceManager.SaveProvince(response.Data);

//            return response.Data;
//        }
//        else
//        {
//            return new List<Dto.Provincia>();
//        }


//    }

//    [HttpPost("getMeteoForProvincia")]
//    public ActionResult<Dto.Meteo> InsertProvinceFromApi(Dto.Provincia provincia)
//    {

//        var urlGeocoding =
//            $"https://geocoding-api.open-meteo.com/v1/search?name={provincia.Nome}&count=10&language=it&format=json";
//        var clientGeocoding = new RestClient(urlGeocoding);
//        var responseGeocoding = clientGeocoding.Execute(new RestRequest());
//        //check that response is ok and deserialize

//        var locationList = Newtonsoft.Json.JsonConvert
//            .DeserializeObject<Dto.GeoCodingResponse>(responseGeocoding.Content).Results;
//        var wantedLocation = locationList.FirstOrDefault(x => x.Admin1 == provincia.Regione);
//        if (wantedLocation == null) return new Dto.Meteo();

//        var urlMeteo =
//            $"https://api.open-meteo.com/v1/forecast?latitude={wantedLocation.Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={wantedLocation.Longitude.ToString(CultureInfo.InvariantCulture)}&hourly=temperature_2m";
//        var clientMeteo = new RestClient(urlMeteo);
//        var responseMeteo = clientMeteo.Execute(new RestRequest());
//        //check that response is ok and deserialize
//        var meteo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dto.Meteo>(responseMeteo.Content);
//        return meteo;

//    }
//}