using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class TernaController
{
    [HttpGet("getToken")]
    public Dto.TernaToken? GetToken()
    {
        return _ternaManager.GetTernaToken();
    }
    

}