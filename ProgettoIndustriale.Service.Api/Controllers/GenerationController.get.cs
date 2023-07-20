using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class GenerationController
{
    [HttpGet("getAllGenerations")]
    public List<Dto.Generation> GetAllGenerations()
    {
        return _generationManager.getAllGenerations();
    }

    [HttpGet("GetGenerationsbyDates")]
    public object GetGenerationsbyDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
    {

        if (startDate > endDate)
        {
            return BadRequest("La data di inizio non può essere successiva alla data di fine");
        }

        if (startDate > DateTime.Now)
        {
            return BadRequest("La data di inizio non può essere futura.");
        }
        if (startDate == default || endDate == default)
        {
            return BadRequest("Inserire data");
        }

        return _generationManager.getGenerationsbyDates(startDate, endDate);
    }
}