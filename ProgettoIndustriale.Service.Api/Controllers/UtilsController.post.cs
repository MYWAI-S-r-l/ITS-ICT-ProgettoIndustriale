using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class UtilsController
{
    [HttpPost("getProvincesDetails")]
    public Object GetProvincesDetails([BindRequired] List<string> prov)
    {
        if (prov.IsNullOrEmpty() || prov[0] == "string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        return _utilsManager.GetProvincesDetails(prov);
    }

    [HttpPost("getNActiveIndustriesbyCatandProv")]
    public Object GetNActiveIndustriesbyCatandProv([BindRequired][FromBody] RequestActiveIndustries activeIndustries)
    {
        if ((!activeIndustries.provincesList.IsNullOrEmpty()) && (activeIndustries.provincesList[0] == "string"))
        {
            return BadRequest("inserire una provincia o mettere la lista vuota");
        }
        if ((!activeIndustries.categoriesList.IsNullOrEmpty()) && (activeIndustries.categoriesList[0] == "string"))
        {
            return BadRequest("inserire una categoria o mettere la lista vuota");
        }
        return _utilsManager.GetNActiveIndustriesbyCatandProv(activeIndustries.provincesList, activeIndustries.categoriesList);
    }
}