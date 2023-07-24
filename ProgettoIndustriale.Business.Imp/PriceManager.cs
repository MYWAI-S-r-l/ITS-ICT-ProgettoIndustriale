using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using System.Diagnostics.CodeAnalysis;
using Dom = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Serilog;
namespace ProgettoIndustriale.Business.Imp;

public class PriceManager : IPriceManager

{
    private readonly ProgettoIndustrialeContext _context;
    public ClassLog _logger { get; set; }
    public PriceManager(ProgettoIndustrialeContext context )
    {
        _context = context;
        _logger = new ClassLog();
    }

    public List<Dto.Price> GetAllPrices()
    {
        try
        {
            var allPrices = _context.Price
            .Include(x => x.Date)
            .Include(x => x.MacroZone)
            .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetAllPrices() ritorna " + allPrices.Count.ToString() + " elementi");


            return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
        }
        catch(Exception ex) 
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Price>();
        }
        
    }

    public List<Dto.Price> GetPricesbyMacrozones([NotNull] List<string> macrozones)
    {
        try
        {
            var allPrices = _context.Price
            .Include(x => x.MacroZone)
            .Include(x => x.Date)
            .Where(x => x.MacroZone != null && x.MacroZone.Name != null && macrozones.Contains(x.MacroZone.Name))
            .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetPricesbyMacrozones() ritorna " + allPrices.Count.ToString() + " elementi");

            return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
        }
        catch (Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Price>();
        }
        
    }

    public List<Dto.Price> GetPricesbyDates([NotNull] DateTime startDate, [NotNull] DateTime endDate)
    {
        try
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("La data di inizio non può essere successiva alla data di fine.");
            }

            if (startDate > DateTime.Today)
            {
                throw new ArgumentException("La data di inizio non può essere futura.");
            }

            var allPrices = _context.Price
                .Include(x => x.Date)
                .Include(x => x.MacroZone)
                .Where(x => x.Date != null && x.MacroZone != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetPricesbyDates() ritorna " + allPrices.Count.ToString() + " elementi");

            return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
        }
        catch (Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Price>();
        }


        
    }

    public List<Dto.Price> GetPricesbyMacrozonesDates([NotNull] List<string> macrozones, [NotNull] DateTime startDate, [NotNull] DateTime endDate)
    {
        try
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("La data di inizio non può essere successiva alla data di fine.");
            }

            if (startDate > DateTime.Today)
            {
                throw new ArgumentException("La data di inizio non può essere futura.");
            }

            var allPrices = _context.Price.Include(x => x.MacroZone)
                .Include(x => x.Date)
                .Where(x => x.Date != null && x.MacroZone != null && x.MacroZone.Name != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate && macrozones
                .Contains(x.MacroZone.Name))
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetPricesbyMacrozonesDates() ritorna " + allPrices.Count.ToString() + " elementi");

            return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
        }
        catch (Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Price>();
        }
       
    }
}
