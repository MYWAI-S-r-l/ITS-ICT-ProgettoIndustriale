using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class EntiController
{
    // TODO: aggiungere check ruolo admin
    [HttpGet("get/{id:int}")]
    public Dto.Ente? GetEnte(int id)
    {
        return _entiManager.GetEnte(id);
    }
    // TODO: aggiungere check ruolo admin
    [HttpGet("getAll")]
    public List<Dto.Ente> GetEnti()
    {
        var user = User;
        var claims = user.Claims;
        return _entiManager.GetAllEnti();
    }
}