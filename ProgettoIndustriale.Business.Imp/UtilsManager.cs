using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Domain = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business.Imp;

//INCLUDE ==> JOIN
public class UtilsManager : IUtilsManager
{
    private readonly ProgettoIndustrialeContext _context;

    public UtilsManager(ProgettoIndustrialeContext context)
    {
        _context = context;
    }

    public List<Dto.Province> GetAllProvinces()
    {
        List<Domain.Province>
            allProvince = _context.Province
                .Include(x => x.Region!)
                .ThenInclude(y => y.MacroZone)
                .Where(x=> x.Region != null && x.Region.MacroZone != null)
                .ToList();

        return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);
    }

    public List<Dto.Province> GetProvincesDetails(List<string> prov)
    {
        List<Domain.Province>
            allProvince = _context.Province
                .Include(x => x.Region!)
                .ThenInclude(y => y.MacroZone)
                .Where(x=> x.Region != null  && x.Region.MacroZone != null && x.Name != null && prov.Contains(x.Name))
                .ToList();

        return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);
    }

    public List<Dto.Region> GetAllRegions()
    {
        var allRegion = _context.Region
            .Include(x => x.MacroZone)
            .ToList();
        return MyMapper<Domain.Region, Dto.Region>.MapList(allRegion);
    }

    public List<Dto.MacroZone> GetAllMacroZone()
    {
        var allMacrozone = _context.MacroZone.ToList();
        return MyMapper<Domain.MacroZone, Dto.MacroZone>.MapList(allMacrozone);
    }

    //QUESTO FORSE NON SERVE
    public List<int> GetRegionsbyName(List<string> reg)
    {
        List<int> regions = _context.Region
            .Include(x => x.MacroZone)
            .Where(x => x.Name != null && reg.Contains(x.Name))
            .Select(x => x.Id)
            .ToList();
        return regions;
    }

    public List<Dto.Province> GetProvincebyRegion(string region)
    {
        List<Domain.Province> listProvinces = _context.Province
            .Include(x => x.Region!)
                .ThenInclude(y => y.MacroZone!)
            .Where(x => x.Region != null && x.Region.MacroZone != null && x.Region.Name == region)
            .ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
    }

    public List<Dto.Province> GetProvincebyMacrozone(string macrozone)
    {
        List<Domain.Province> listProvinces = _context.Province
            .Include(x => x.Region!)
                .ThenInclude(r => r.MacroZone)
            .Where(x => x.Region != null && x.Region.MacroZone != null && x.Region.MacroZone.Name != null && x.Region.MacroZone.Name == macrozone)
            .ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
    }

    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone)
    {
        List<Domain.Region> listRegions = _context.Region
            .Include(r => r.MacroZone)
            .Where(x => x.MacroZone != null && x.MacroZone.Name == macrozone).ToList();
        return MyMapper<Domain.Region, Dto.Region>.MapList(listRegions);
    }

    public Dto.MacroZone GetMacrozoneHavingRegion(string region)
    {
        Domain.MacroZone? macrozone = _context.Region
            .Include(x => x.MacroZone!)
            .Where(x => x.MacroZone != null && x.Name != null && x.Name == region)
            .Select(x => x.MacroZone)
            .FirstOrDefault();
        return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone!);
    }

    public Dto.MacroZone GetMacrozoneHavingProvince(string province)
    {
       
        Domain.MacroZone? macrozone = _context.Province
            .Include(x => x.Region!)
            .ThenInclude(y => y.MacroZone!)
            .Where(x=> x.Region != null && x.Region.MacroZone != null && x.Name != null)
            .FirstOrDefault(x => x.Name == province)?.Region?.MacroZone;
            
        return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone!);
       
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

        List<Business.IUtilsManager.MyAtecoClass> result;
        if (category.IsNullOrEmpty())
        {
            result = _context.Industry
               .Include(x => x.Province!)
               .Where(x =>x.Province != null && x.Province.Name != null && lProvinces.Contains(x.Province))
               .GroupBy(x => new Tuple<string, string>(x.Province.Name!, x.Ateco))
               .Select(x => new Business.IUtilsManager.MyAtecoClass
               (
                   x.Key!.Item1!,
                   x.Key.Item2,
                   x.Sum(y => y.CountActive)
               ))
               .ToList();
        }
        else
        {
            result = _context.Industry
                .Include(x => x.Province!)
                .Where(x => x.Province != null && x.Province.Name != null && lProvinces.Contains(x.Province) && category.Contains(x.Ateco))
                .GroupBy(x => new Tuple<string, string>(x.Province.Name!, x.Ateco))
                .Select(x => new Business.IUtilsManager.MyAtecoClass
                (
                    x.Key.Item1,
                    x.Key.Item2,
                    x.Sum(y => y.CountActive)
                )).ToList();
        }

        return result;
    }
}