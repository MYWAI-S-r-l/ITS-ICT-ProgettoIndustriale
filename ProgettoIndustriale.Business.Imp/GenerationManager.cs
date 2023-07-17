using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Dto;
using System.Diagnostics.CodeAnalysis;
using Domain = ProgettoIndustriale.Type.Domain;

using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business.Imp;

public class GenerationManager : IGenerationManager

{
    private readonly ProgettoIndustrialeContext _context;

    public GenerationManager(ProgettoIndustrialeContext context)
    {
        _context = context;
    }

    public List<Dto.Generation> getAllGenerations()
    {
        var allGenerations = _context.Generation.ToList();
        return MyMapper<Domain.Generation, Dto.Generation>.MapList(allGenerations);
    }

    public List<Generation> getGenerationsbyDates([NotNull] DateTime startDate, [NotNull] DateTime endDate)
    {
        var allGenerations = _context.Generation
            .Where(x => x.Date != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate)
            .ToList();
        return MyMapper<Domain.Generation, Dto.Generation>.MapList(allGenerations);
    }
}