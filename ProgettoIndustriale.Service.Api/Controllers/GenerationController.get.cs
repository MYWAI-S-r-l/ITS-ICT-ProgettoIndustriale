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

        if (CheckDate.TryDateCheck(startDate, endDate))
        {
            return _generationManager.getGenerationsbyDates(startDate, endDate);    

        }
        else
        {

            _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getGenerationsbyDates() " + CheckDate.errorMessage);

            return new BadRequestObjectResult(CheckDate.errorMessage);
        }

    }
}