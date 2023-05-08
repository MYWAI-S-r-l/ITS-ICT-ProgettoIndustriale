using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class EntiController
{
    [HttpGet("get/{id:int}")]
    public Dto.Ente? GetEnte(int id)
    {
        return _entiManager.GetEnte(id);
    }
    
    [HttpGet("getAll")]
    public List<Dto.Ente> GetEnti()
    {
        return _entiManager.GetAllEnti();
    }
}