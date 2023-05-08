using Microsoft.AspNetCore.Mvc;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class EntiController
{
    [HttpPost("upsertEnte")]
    public ActionResult<Dto.Ente?> UpsertEnte([FromBody] Dto.Ente? ente)
    {
        if (ente == null)
            return BadRequest("Impossible to edit a null Ente.");
        return ente.Id != 0 ? _entiManager.EditEnte(ente) : _entiManager.SaveEnte(ente);
    }
    
    [HttpPost("delete/{id:int}")]
    public ActionResult<bool> DeleteEnte(int id)
    {
        return _entiManager.DeleteEnte(id);
    }
}