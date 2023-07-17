using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;


public interface IUtilsManager
{
    public List<Dto.Province> GetAllProvinces();
    public List<Dto.Region> GetAllRegions();
    public List<Dto.MacroZone> GetAllMacroZone();

    public List<Dto.Province> GetProvincesDetails(List<string> prov);

    public List<Dto.Province> GetProvincebyMacrozone(string macrozone);
    public Dto.MacroZone GetMacrozoneHavingProvince(string province);
    public List<Dto.Province> GetProvincebyRegion(string region);//nome
    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone);

    public Dto.MacroZone GetMacrozoneHavingRegion(string region);
    public List<MyAtecoClass> GetNActiveIndustriesbyCatandProv(List<string> provinces, List<string> category);

   
    public class MyAtecoClass
    {

        public MyAtecoClass()
        {
        }

        public MyAtecoClass(string prov, string ateco, int nIndusries)
        {
    
            this.Prov = prov;
            this.Ateco = ateco; 
            this.NIndustries = nIndusries; 
        }


        public string Prov { get; set; } = null!;
        public string Ateco { get; set; } = null!;
    public int NIndustries { get; set; }
    }
       
}