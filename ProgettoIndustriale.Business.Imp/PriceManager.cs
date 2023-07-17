using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using System.Diagnostics.CodeAnalysis;
using Dom = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business.Imp;

public class PriceManager : IPriceManager

{
    private readonly ProgettoIndustrialeContext _context;

    public PriceManager(ProgettoIndustrialeContext context)
    {
        _context = context;
    }

    public List<Dto.Price> GetAllPrices()
    {
        var allPrices = _context.Price
            .Include(x => x.Date)
            .Include(x => x.MacroZone)
            .ToList();
        return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
    }

    public List<Dto.Price> GetPricesbyMacrozones([NotNull] List<string> macrozones)
    {
        var allPrices = _context.Price
            .Include(x => x.MacroZone)
            .Include(x => x.Date)
            .Where(x => x.MacroZone != null && x.MacroZone.Name != null && macrozones.Contains(x.MacroZone.Name))
            .ToList();
        return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
    }

    public List<Dto.Price> GetPricesbyDates([NotNull] DateTime startDate, [NotNull] DateTime endDate)
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
        return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
    }

    public List<Dto.Price> GetPricesbyMacrozonesDates([NotNull] List<string> macrozones, [NotNull] DateTime startDate, [NotNull] DateTime endDate)
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

        return MyMapper<Dom.Price, Dto.Price>.MapList(allPrices);
    }
}
