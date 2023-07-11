using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class UtilsController
{


    [HttpPost("getProvincesDetails")]
    public Object GetProvincesDetails(List<string> prov)
    {
        if(prov.IsNullOrEmpty()||prov.First()=="string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        return _utilsManager.GetProvincesDetails(prov);
    }

    [HttpPost("getNActiveIndustriesbyCatandProv")]
    public List<Business.IUtilsManager.MyAtecoClass> GetNActiveIndustriesbyCatandProv([FromBody] RequestActiveIndustries activeIndustries)
    {
        return _utilsManager.GetNActiveIndustriesbyCatandProv(activeIndustries.provincesList, activeIndustries.categoriesList);
    }
}




