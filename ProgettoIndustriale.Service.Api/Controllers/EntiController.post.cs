using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class EntiController
{
    // TODO: aggiungere check ruolo admin
    [HttpPost("upsertEnte")]
    [AllowAnonymous]
    public ActionResult<Dto.Ente?> UpsertEnte([FromBody] Dto.Ente? ente)
    {
        var utenteAttivo = User; //TODO: chiedere come fare giro per controllo permessi
        if (ente == null)
            return BadRequest("Impossible to edit a null Ente.");
        return ente.Id != 0 ? _entiManager.EditEnte(ente) : _entiManager.SaveEnte(ente);
    }
    
    // TODO: aggiungere check ruolo admin
    [HttpPost("delete/{id:int}")]
    public ActionResult<bool> DeleteEnte(int id)
    {
        return _entiManager.DeleteEnte(id);
    }
}