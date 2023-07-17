using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using System.Diagnostics.CodeAnalysis;
using Domain = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business.Imp
{
    public class CommodityManager : ICommodityManager
    {
        private readonly ProgettoIndustrialeContext _context;

        public CommodityManager(ProgettoIndustrialeContext context)
        {
            _context = context;
        }

        public List<Dto.Commodity> getAllCommodities()
        {
            List<Domain.Commodity> commodities = _context.Commodity.ToList();
            return MyMapper<Domain.Commodity, Dto.Commodity>.MapList(commodities);
        }

        public List<Dto.Commodity> getComoditybyDates([NotNull] DateTime startDate, [NotNull] DateTime endDate)
        {
            List<Domain.Commodity> commodities = _context.Commodity
                .Include(x => x.Date)
                .Where(x => x.Date != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate)
                .ToList();
            return MyMapper<Domain.Commodity, Dto.Commodity>.MapList(commodities);
        }
    }
}