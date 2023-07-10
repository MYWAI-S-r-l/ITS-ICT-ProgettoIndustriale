using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class UtilsController
{
    [HttpPost("getAllProvinces")]
    public List<Dto.Province> GetAllProvinces(List<string> prov)
    {
        return _utilsManager.GetAllProvinces(prov);
    }
    [HttpPost("getProvincebyRegion")]
    public List<Dto.Province> GetProvincebyRegion(List<string> regions)
    {
        return _utilsManager.GetProvincebyRegion(regions);
    }

    [HttpPost("GetNActiveIndustriesbyCatandProv")]
    public List<Business.IUtilsManager.MyAtecoClass> GetNActiveIndustriesbyCatandProv([FromBody] RequestActiveIndustries activeIndustries)
    {
        return _utilsManager.GetNActiveIndustriesbyCatandProv(activeIndustries.provincesList, activeIndustries.categoriesList);
    }
}




