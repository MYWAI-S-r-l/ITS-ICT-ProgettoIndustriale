using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public Object GetProvincesDetails([BindRequired] List<string> prov)
    {
        if(prov.IsNullOrEmpty()||prov.First()=="string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        return _utilsManager.GetProvincesDetails(prov);
    }

    [HttpPost("getNActiveIndustriesbyCatandProv")]
    public Object GetNActiveIndustriesbyCatandProv([FromBody] RequestActiveIndustries activeIndustries)
    {
        if (!activeIndustries.provincesList.IsNullOrEmpty())
        {
            if (activeIndustries.provincesList.First() == "string")
            {
                return BadRequest("inserire una provincia o mettere la lista vuota");
            }
        }
        if (!activeIndustries.categoriesList.IsNullOrEmpty())
        {
            if (activeIndustries.categoriesList.First() == "string")
            {
                return BadRequest("inserire una categoria o mettere la lista vuota");
            }
        }
        return _utilsManager.GetNActiveIndustriesbyCatandProv(activeIndustries.provincesList, activeIndustries.categoriesList);
    }
}




