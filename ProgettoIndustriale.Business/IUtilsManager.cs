using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;


public interface IUtilsManager
{
    public List<Dto.Province> GetAllProvinces();
    public List<Dto.Province> GetProvincebyMacrozone(string macrozone);
    public Dto.MacroZone getMacrozoneHavingProvince(string province);
    public List<Dto.Province> GetProvincebyRegion(List<string> regions);//nome
    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone);

    public Dto.MacroZone getMacrozoneHavingRegion(string region);
    public List<int> GetNActiveIndustriesbyCatandProv(List<Dto.Province> provinces, List<string> category);


}