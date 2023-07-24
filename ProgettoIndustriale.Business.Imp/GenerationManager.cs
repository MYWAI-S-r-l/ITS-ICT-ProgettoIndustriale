using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Dto;
using System.Diagnostics.CodeAnalysis;
using Domain = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Serilog;

namespace ProgettoIndustriale.Business.Imp;

public class GenerationManager : IGenerationManager

{
    private readonly ProgettoIndustrialeContext _context;
    public ClassLog _logger { get; set; }
    public GenerationManager(ProgettoIndustrialeContext context, IConfiguration config)
    {
        _context = context;
        _logger = new ClassLog(config);
    }

    public List<Dto.Generation> getAllGenerations()
    {
        try
        {
            var allGenerations = _context.Generation.ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetAllGenerations() ritorna " + allGenerations.Count.ToString() + " elementi");

            return MyMapper<Domain.Generation, Dto.Generation>.MapList(allGenerations);

        }
        catch (Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Generation>();
        }
    }

    public List<Generation> getGenerationsbyDates([NotNull] DateTime startDate, [NotNull] DateTime endDate)
    {
        try
        {


            var allGenerations = _context.Generation
                .Where(x => x.Date != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getGenerationsbyDates() ritorna " + allGenerations.Count.ToString() + " elementi");

            return MyMapper<Domain.Generation, Dto.Generation>.MapList(allGenerations);

        }
        catch (Exception ex)
        {

            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Generation>();

        }

    }
}