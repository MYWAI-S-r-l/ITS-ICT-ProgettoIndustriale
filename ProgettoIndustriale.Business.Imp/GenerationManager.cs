﻿using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Data;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using Azure;

namespace ProgettoIndustriale.Business.Imp;
public class GenerationManager : IGenerationManager

{
    private readonly ProgettoIndustrialeContext _context;
    public GenerationManager(ProgettoIndustrialeContext context)
    { 
        _context= context;
    }

    public List<Dto.Generation> getAllGenerations()
    {

        var allGenerations = _context.Generation.ToList();
        return MyMapper<Domain.Generation, Dto.Generation>.MapList(allGenerations);

    }

   

    public List<Generation> getGenerationsbyDates(DateTime startDate, DateTime endDate)
    {
        
        var allGenerations = _context.Generation
            .Where(x => x.Date.DateTime > startDate && x.Date.DateTime < endDate).ToList();
        return MyMapper<Domain.Generation, Dto.Generation>.MapList(allGenerations);
    }
}
