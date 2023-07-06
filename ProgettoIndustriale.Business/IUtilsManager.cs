using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;


public interface IUtilsManager
{
    public List<Dto.Province> GetAllProvinces();
    public List<Dto.Region> GetAllRegions();
    public List<Dto.MacroZone> GetAllMacroZone();

    public List<Dto.Province> GetProvincebyMacrozone(string macrozone);
    public Dto.MacroZone GetMacrozoneHavingProvince(string province);
    public List<Dto.Province> GetProvincebyRegion(List<string> regions);//nome
    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone);

    public Dto.MacroZone GetMacrozoneHavingRegion(string region);
    public List<Tuple<string, string, int>> GetNActiveIndustriesbyCatandProv(List<Dto.Province> provinces=null, List<string> category=null);


}