﻿using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Data;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Type.Domain;
using System.Security.Cryptography.X509Certificates;

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

        var allProvince = _context.Province.ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);

    }
    public List<Dto.Region> GetAllRegions()
    {

        var allRegion = _context.Region.ToList();
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
        List<int> regions = _context.Region.Where(x => reg.Contains(x.Name)).Select(x => x.Id).ToList();
        /*
        foreach (var item in reg)
        {

            regions.Add(_context.Region.Where(r => r.Name == item).FirstOrDefault().Id);

        }
        */
        return regions;
    }

    public List<Dto.Province> GetProvincebyRegion(List<string> regions)
    {
        //CON LA FUNZIONE APPENA CREATA
        /*
        List<int> idRegions = GetRegionsbyName(regions);
        List<Domain.Province> listProvinces = _context.Province.Where(p => idRegions.Contains(p.IdRegion)).ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
        */

        //
        List<Domain.Province> listProvinces = _context.Province.Include(x => x.Region).Where(x => regions.Contains(x.Region.Name)).ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
        
        
        }

    public List<Dto.Province> GetProvincebyMacrozone(string macrozone)
    {
        List<Domain.Province> listProvinces = _context.Province
            .Include(x => x.Region)
                .ThenInclude(r => r.MacroZone)
            .Where(x => x.Region.MacroZone.Name == macrozone).ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
    }

    public List<Dto.Region> GetRegionsbyMacrozone(string macrozone)
    {
        List<Domain.Region> listRegions = _context.Region
            .Include(r => r.MacroZone)
            .Where(x => x.MacroZone.Name == macrozone).ToList();
        return MyMapper<Domain.Region, Dto.Region>.MapList(listRegions);
    }

    public Dto.MacroZone GetMacrozoneHavingRegion(string region)
    {
        Domain.MacroZone macrozone=_context.Region.Where(x=>x.Name==region).Select(x=>x.MacroZone).First();
        return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone);
    }

    public Dto.MacroZone GetMacrozoneHavingProvince(string province)
    {
        Domain.MacroZone macrozone = _context.Province.Where(x => x.Region.Name == province).Select(x => x.Region.MacroZone).First();
        return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone);
    }

    public List<int> GetNActiveIndustriesbyCatandProv(List<Dto.Province> provinces = null, List<string> category = null)
    {
        List<int> nactive =new List<int>();
        if(provinces==null)
        {
            provinces = GetAllProvinces();
        }
        List<Domain.Province> lProvinces = MyMapper<Dto.Province, Domain.Province>.MapList(provinces);
        if (category==null)
        {
            nactive = _context.Industry.Include(x => x.Province).Where(x => lProvinces.Contains(x.Province)).Select(x => x.CountActive).ToList();
        }
        else
        {
            nactive = _context.Industry.Include(x => x.Province).Where(x => lProvinces.Contains(x.Province) && category.Contains(x.Name)).Select(x => x.CountActive).ToList();
        }


        return nactive;
    }

   
}
