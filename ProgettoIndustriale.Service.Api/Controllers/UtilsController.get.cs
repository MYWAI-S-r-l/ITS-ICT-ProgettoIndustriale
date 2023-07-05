using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class UtilsController
{
    

    [HttpGet("getAllProvinces")]
    public List<Dto.Province> GetAllProvinces()
    {
        return _utilsManager.GetAllProvinces();
    }
    [HttpGet("getAllRegions")]
    public List<Dto.Region> GetAllRegions()
    {
        return _utilsManager.GetAllRegions();
    }
    [HttpGet("getAllMacroZone")]
    public List<Dto.MacroZone> GetAllMacroZone()
    {
        return _utilsManager.GetAllMacroZone();
    }

    [HttpGet("getProvincebyMacrozone/{macrozone}")]
    public List<Dto.Province> GetProvincebyMacrozone(string macrozone)
    {
        return _utilsManager.GetProvincebyMacrozone(macrozone);
    }
    [HttpGet("getMacrozoneHavingProvince/{province}")]
    public Dto.MacroZone getMacrozoneHavingProvince(string province)
    {
        return _utilsManager.GetMacrozoneHavingProvince(province);
    }
    [HttpGet("getRegionsbyMacrozone/{macrozone}")]
    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone)
    {
        return _utilsManager.GetRegionsbyMacrozone(macrozone);
    }
    [HttpGet("getMacrozoneHavingRegion/{region}")]
    public Dto.MacroZone GetMacrozoneHavingRegion(string region)
    {
        return _utilsManager.GetMacrozoneHavingRegion(region);
    }




}

