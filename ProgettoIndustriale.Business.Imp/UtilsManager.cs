using Ansaldo.Protocollo.Business.Imp;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using System.Xml.Serialization;
using Domain = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace ProgettoIndustriale.Business.Imp;

//INCLUDE ==> JOIN
public class UtilsManager : IUtilsManager
{
    private readonly ProgettoIndustrialeContext _context;
    public ClassLog _logger { get; set; }
    public UtilsManager(ProgettoIndustrialeContext context, ClassLog _genericLogger)
    {

        _context = context;
        _logger = _genericLogger;
    }

    public List<Dto.Province> GetAllProvinces()
    {
       
        try
        {
            
            List<Domain.Province>
                allProvince = _context.Province
                    .Include(x => x.Region!)
                    .ThenInclude(y => y.MacroZone!)
                    .Where(x => x.Region != null && x.Region.MacroZone != null)
                    .ToList();

            _logger.logMessageTemplate(path: this.ToString()!,logType: "debug", message: "GetAllProvinces() ritorna "+allProvince.Count.ToString()+" elementi");

            return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);
        }
        catch(Exception ex) 
        {

            _logger.logMessageTemplate(path: this.ToString()!,e: ex);
           
            return new List<Dto.Province>();

        }
    }

    public List<Dto.Province> GetProvincesDetails(List<string> prov)
    {
        try
        {
            List<Domain.Province>
            allProvince = _context.Province
                .Include(x => x.Region!)
                .ThenInclude(y => y.MacroZone)
                .Where(x => x.Region != null && x.Region.MacroZone != null && x.Name != null && prov.Contains(x.Name))
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetProvincesDetails() ritorna " + allProvince.Count.ToString() + " elementi");

            return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Province>();
        }
    }

    public List<Dto.Region> GetAllRegions()
    {
        try
        {

            var allRegion = _context.Region
                .Include(x => x.MacroZone)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetAllRegions() ritorna " + allRegion.Count.ToString() + " elementi");

            return MyMapper<Domain.Region, Dto.Region>.MapList(allRegion);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Region>();
        }
    }

    public List<Dto.MacroZone> GetAllMacroZone()
    {
        try
        {
            var allMacrozone = _context.MacroZone.ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetAllMacroZone() ritorna " + allMacrozone.Count.ToString() + " elementi");

            return MyMapper<Domain.MacroZone, Dto.MacroZone>.MapList(allMacrozone);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.MacroZone>();
        }
    }

    //QUESTO FORSE NON SERVE
    public List<int> GetRegionsbyName(List<string> reg)//ritorna una lista di id region
    {
        try
        {
            List<int> regions = _context.Region
                .Include(x => x.MacroZone)
                .Where(x => x.Name != null && reg.Contains(x.Name))
                .Select(x => x.Id)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetRegionsbyName() ritorna " + regions.Count.ToString() + " elementi");

            return regions;
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<int>();
        }
    }

    public List<Dto.Province> GetProvincebyRegion(string region)
    {
        try
        {
            List<Domain.Province> listProvinces = _context.Province
                .Include(x => x.Region!)
                    .ThenInclude(y => y.MacroZone!)
                .Where(x => x.Region != null && x.Region.MacroZone != null && x.Region.Name == region)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetProvincebyRegion() ritorna " + listProvinces.Count.ToString() + " elementi");

            return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Province>();
        }
    }

    public List<Dto.Province> GetProvincebyMacrozone(string macrozone)
    {
        try
        {
            List<Domain.Province> listProvinces = _context.Province
                .Include(x => x.Region!)
                    .ThenInclude(r => r.MacroZone)
                .Where(x => x.Region != null && x.Region.MacroZone != null && x.Region.MacroZone.Name != null && x.Region.MacroZone.Name == macrozone)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetProvincebyMacrozone() ritorna " + listProvinces.Count.ToString() + " elementi");

            return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Province>();
        }
    }

    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone)
    {
        try
        {

            List<Domain.Region> listRegions = _context.Region
                .Include(r => r.MacroZone)
                .Where(x => x.MacroZone != null && x.MacroZone.Name == macrozone).ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetRegionsbyMacrozone() ritorna " + listRegions.Count.ToString() + " elementi");

            return MyMapper<Domain.Region, Dto.Region>.MapList(listRegions);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Region>();
        }
    }

    public Dto.MacroZone GetMacrozoneHavingRegion(string region)
    {
        try
        {
            Domain.MacroZone? macrozone = _context.Region
                .Include(x => x.MacroZone!)
                .Where(x => x.MacroZone != null && x.Name != null && x.Name == region)
                .Select(x => x.MacroZone)
                .FirstOrDefault();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetMacrozoneHavingRegion() ritorna " + MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone!)!.ToString());

            return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone!);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new Dto.MacroZone();
        }
    }

    public Dto.MacroZone GetMacrozoneHavingProvince(string province)
    {
        try
        {
            Domain.MacroZone? macrozone = _context.Province
                .Include(x => x.Region!)
                .ThenInclude(y => y.MacroZone!)
                .Where(x => x.Region != null && x.Region.MacroZone != null && x.Name != null)
                .FirstOrDefault(x => x.Name == province)?.Region?.MacroZone;

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetMacrozoneHavingProvince() ritorna " + MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone!).ToString());

            return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone!);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new Dto.MacroZone();
        }
       
    }

    public List<Business.IUtilsManager.MyAtecoClass> GetNActiveIndustriesbyCatandProv(List<string> provinces, List<string> category)
    {
        //ottengo la lista delle province con i nomi passati dalla lista
        List<Dto.Province> prov;
        if (provinces.IsNullOrEmpty())
        {
            prov = GetAllProvinces();
        }
        else
        {
            prov = GetProvincesDetails(provinces);
        }
        List<Domain.Province> lProvinces = MyMapper<Dto.Province, Domain.Province>.MapList(prov);

        List<Business.IUtilsManager.MyAtecoClass> result= new List<Business.IUtilsManager.MyAtecoClass>();
        if (category.IsNullOrEmpty())//lista delle categorie vuota
        {
            try
            {


                result = _context.Industry
                   .Include(x => x.Province!)
                   .Where(x => x.Province != null && x.Province.Name != null && lProvinces.Contains(x.Province))
                   .GroupBy(x => new Tuple<string, string>(x.Province!.Name!, x.Ateco!))
                   .Select(x => new Business.IUtilsManager.MyAtecoClass
                   (
                       x.Key!.Item1!,
                       x.Key.Item2,
                       x.Sum(y => y.CountActive)
                   ))
                   .ToList();
                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetNActiveIndustriesbyCatandProv() ritorna " + result.Count.ToString() + " elementi");

            }
            catch (Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return result;
            }
        }
        else//lista di categorie non è vuota
        {
            try
            {
                result = _context.Industry
                    .Include(x => x.Province!)
                    .Where(x => x.Province != null && x.Province.Name != null && lProvinces.Contains(x.Province) && category.Contains(x.Ateco!))
                    .GroupBy(x => new Tuple<string, string>(x.Province!.Name!, x.Ateco!))
                    .Select(x => new Business.IUtilsManager.MyAtecoClass
                    (
                        x.Key.Item1,
                        x.Key.Item2,
                        x.Sum(y => y.CountActive)
                    )).ToList();

                _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetNActiveIndustriesbyCatandProv() ritorna " + result.Count.ToString() + " elementi");


            }
            catch (Exception ex)
            {
                _logger.logMessageTemplate(path: this.ToString()!, e: ex);

                return result;
            }
        }

        return result;
    }
}