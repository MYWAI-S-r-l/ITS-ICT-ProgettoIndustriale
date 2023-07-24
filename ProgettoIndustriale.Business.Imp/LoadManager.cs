using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Dto;
using System.Diagnostics.CodeAnalysis;
using Dom = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Serilog;
namespace Ansaldo.Protocollo.Business.Imp
{
    public class LoadManager : ILoadManager
    {
        private readonly ProgettoIndustrialeContext _context;
        public ClassLog _logger { get; set; }

        public LoadManager(ProgettoIndustrialeContext context, IConfiguration config)
        {
            _context = context;
            _logger = new ClassLog(config);
        }

        public List<Dto.Load> getAllLoads()
        {
            try 
            {
                List<Dom.Load> loads = _context.Load
                .Include(x => x.MacroZone)
                .Include(y => y.Date)
                .ToList();

                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getAllLoads() ritorna " + loads.Count.ToString() + " elementi");

                return MyMapper<Dom.Load, Dto.Load>.MapList(loads);
            }
            catch(Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return new List<Dto.Load>();
            }
            
        }

        // Questo metodo restituisce una lista di oggetti Load filtrata per data di inizio e data di fine

        public List<Dto.Load> getloadbyDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Dom.Load> loads = _context.Load
                .Include(x => x.MacroZone)
                .Include(y => y.Date)
                .Where(c => c.Date.DateTime > startDate && c.Date.DateTime < endDate)
                .ToList();

                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getloadbyDates() ritorna " + loads.Count.ToString() + " elementi");

                return MyMapper<Dom.Load, Dto.Load>.MapList(loads);
            }
            catch (Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return new List<Dto.Load>();
            }
            
        }

        // Questo metodo restituisce una lista di oggetti Load filtrata per nome di macrozone, usando il metodo Include per caricare la relazione con l’entità MacroZone
        public List<Dto.Load> getLoadbyMacrozone([NotNull]List<string> nameMacroZone)
        {
            try
            {
                List<Dom.Load> loads = _context.Load
                .Include(x => x.MacroZone)
                .Where(x => x.MacroZone != null && x.MacroZone.Name != null && nameMacroZone.Contains(x.MacroZone.Name))
                .ToList();

                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getLoadbyMacrozone() ritorna " + loads.Count.ToString() + " elementi");

                return MyMapper<Dom.Load, Dto.Load>.MapList(loads).ToList();
            }
            catch (Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return new List<Dto.Load>();
            }
            
        }

        // Questo metodo restituisce una lista di oggetti Dto.Load filtrata per macrozone, data di inizio e data di fine, usando il metodo Include per caricare la relazione con l’entità Date
        public List<Dto.Load> getLoadsbyFilter(string macrozone, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Dom.Load> loads = _context.Load
                                 .Include(x => x.Date)
                                 .Where(p => p.Date.DateTime > startDate && p.Date.DateTime < endDate && p.MacroZone.Name == macrozone)
                                 .ToList();

                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "getLoadsbyFilter() ritorna " + loads.Count.ToString() + " elementi");

                return MyMapper<Dom.Load, Dto.Load>.MapList(loads);
            }
            catch (Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return new List<Dto.Load>();
            }
            
        }
    }
}