using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using System.Diagnostics.CodeAnalysis;
using Domain = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Serilog;
namespace ProgettoIndustriale.Business.Imp
{
    public class CommodityManager : ICommodityManager
    {
        private readonly ProgettoIndustrialeContext _context;
        public ClassLog _logger { get; set; }
        public CommodityManager(ProgettoIndustrialeContext context)
        {
            _context = context;
            _logger = new ClassLog();
            
        }

        public List<Dto.Commodity> getAllCommodities()
        {
            
            try
            {
                List<Domain.Commodity> commodities = _context.Commodity.ToList();
                
                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getAllCommodities() ritorna " + commodities.Count.ToString() + " elementi");

                return MyMapper<Domain.Commodity, Dto.Commodity>.MapList(commodities);

            }
            catch (Exception ex)
            {

                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return new List<Dto.Commodity>();
            }
            
        }

        public List<Dto.Commodity> getComoditybyDates([NotNull] DateTime startDate, [NotNull] DateTime endDate)
        {
            try
            {
                List<Domain.Commodity> commodities = _context.Commodity
                    .Include(x => x.Date)
                    .Where(x => x.Date != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate)
                    .ToList();

                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getComoditybyDates() ritorna " + commodities.Count.ToString() + " elementi");

                return MyMapper<Domain.Commodity, Dto.Commodity>.MapList(commodities);
            }
            catch(Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return new List<Dto.Commodity>();
            }
        }
    }
}