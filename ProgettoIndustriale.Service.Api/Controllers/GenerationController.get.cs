using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class GenerationController
{
    

    [HttpGet("getAllGenerations")]
    public List<Dto.Generation> GetAllGenerations()
    {
        return _generationManager.getAllGenerations();
    }
    [HttpGet("GetGenerationsbyDates/{startDate}/{endDate}")]
    public List<Dto.Generation> GetGenerationsbyDates(DateTime startDate, DateTime endDate)
    {
        return _generationManager.getGenerationsbyDates(startDate,endDate);
    }
    



}

