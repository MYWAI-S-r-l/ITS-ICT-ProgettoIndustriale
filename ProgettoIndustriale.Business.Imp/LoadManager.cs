using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Dto;
using System.Diagnostics.CodeAnalysis;
using Dom = ProgettoIndustriale.Type.Domain;

using Dto = ProgettoIndustriale.Type.Dto;

namespace Ansaldo.Protocollo.Business.Imp
{
    public class LoadManager : ILoadManager
    {
        private readonly ProgettoIndustrialeContext _context;

        public LoadManager(ProgettoIndustrialeContext context)
        {
            _context = context;
        }

        public List<Dto.Load> getAllLoads()
        {
            List<Dom.Load> loads = _context.Load
                .Include(x => x.MacroZone)
                .Include(y => y.Date)
                .ToList();
            return MyMapper<Dom.Load, Dto.Load>.MapList(loads);
        }

        // Questo metodo restituisce una lista di oggetti Load filtrata per data di inizio e data di fine

        public List<Load> getloadbyDates(DateTime startDate, DateTime endDate)
        {
            List<Dom.Load> loads = _context.Load
                .Include(x => x.MacroZone)
                .Include(y => y.Date)
                .Where(c => c.Date.DateTime > startDate && c.Date.DateTime < endDate)
                .ToList();
            return MyMapper<Dom.Load, Dto.Load>.MapList(loads);
        }

        // Questo metodo restituisce una lista di oggetti Load filtrata per nome di macrozone, usando il metodo Include per caricare la relazione con l’entità MacroZone
        public List<Load> getLoadbyMacrozone([NotNull]List<string> nameMacroZone)
        {
            List<Dom.Load> loads = _context.Load
                .Include(x => x.MacroZone)
                .Where(x => x.MacroZone != null && x.MacroZone.Name != null && nameMacroZone.Contains(x.MacroZone.Name))
                .ToList();
            return MyMapper<Dom.Load, Dto.Load>.MapList(loads).ToList();
        }

        // Questo metodo restituisce una lista di oggetti Dto.Load filtrata per macrozone, data di inizio e data di fine, usando il metodo Include per caricare la relazione con l’entità Date
        public List<Dto.Load> getLoadsbyFilter(string macrozone, DateTime startDate, DateTime endDate)
        {
            List<Dom.Load> loads = _context.Load
                 .Include(x => x.Date)
                 .Where(p => p.Date.DateTime > startDate && p.Date.DateTime < endDate && p.MacroZone.Name == macrozone)
                 .ToList();
            return MyMapper<Dom.Load, Dto.Load>.MapList(loads);
        }
    }
}