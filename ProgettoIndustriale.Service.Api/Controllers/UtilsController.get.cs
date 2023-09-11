using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dto = ProgettoIndustriale.Type.Dto;

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

    [HttpGet("getMacrozoneHavingProvince")]
    public Object getMacrozoneHavingProvince([BindRequired] string province)
    {
        return _utilsManager.GetMacrozoneHavingProvince(province);
    }

    [HttpGet("getRegionsbyMacrozone")]
    public Object GetRegionsbyMacrozone([BindRequired] string macrozone)
    {
        return _utilsManager.GetRegionsbyMacrozone(macrozone);
    }

    [HttpGet("getMacrozoneHavingRegion")]
    public Object GetMacrozoneHavingRegion([BindRequired] string region)
    {
        return _utilsManager.GetMacrozoneHavingRegion(region);
    }

    [HttpGet("getProvincebyRegion")]
    public Object GetProvincebyRegion([BindRequired] string region)
    {
        return _utilsManager.GetProvincebyRegion(region);
    }

    [HttpGet("getProvincebyMacrozone")]
    public Object GetProvincebyMacrozone([BindRequired] string macrozone)
    {
        return _utilsManager.GetProvincebyMacrozone(macrozone);
    }

    [HttpGet("getLastCommodities")]
    public Object GetLastCommodities()
    {
        return _utilsManager.GetLastCommodities();
    }
}