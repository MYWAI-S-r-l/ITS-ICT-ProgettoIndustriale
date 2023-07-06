using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class UtilsController
{
    [HttpPost("getProvincebyRegion")]
    public List<Dto.Province> GetProvincebyRegion(List<string> regions)
    {
        return _utilsManager.GetProvincebyRegion(regions);
    }

    [HttpPost("GetNActiveIndustriesbyCatandProv")]
    public List<Tuple<string, string, int>> GetNActiveIndustriesbyCatandProv([FromBody] RequestActiveIndustries activeIndustries)
    {
        return _utilsManager.GetNActiveIndustriesbyCatandProv(activeIndustries.provincesList, activeIndustries.categoriesList);
    }
}




