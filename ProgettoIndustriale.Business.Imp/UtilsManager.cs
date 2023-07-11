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
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Tokens;

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
        List <Domain.Province> 
            allProvince = _context.Province
                .Include(x => x.Region)
                .ThenInclude(y => y.MacroZone)
                .ToList();
     
        return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);

    }

    public List<Dto.Province> GetProvincesDetails(List<string> prov)
    {
        List<Domain.Province> 
            allProvince = _context.Province
                .Include(x => x.Region)
                .ThenInclude(y => y.MacroZone)
                .Where(x => prov.Contains(x.Name))
                .ToList();
        
        return MyMapper<Domain.Province, Dto.Province>.MapList(allProvince);
    }



     public List<Dto.Region> GetAllRegions()
     {

        var allRegion = _context.Region
            .Include(x=>x.MacroZone)
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
            .Where(x => reg.Contains(x.Name)).Select(x => x.Id).ToList();
        /*
        foreach (var item in reg)
        {

            regions.Add(_context.Region.Where(r => r.Name == item).FirstOrDefault().Id);

        }
        */
        return regions;
    }

    public List<Dto.Province> GetProvincebyRegion(string region)
    {
        //CON LA FUNZIONE APPENA CREATA
        /*
        List<int> idRegions = GetRegionsbyName(regions);
        List<Domain.Province> listProvinces = _context.Province.Where(p => idRegions.Contains(p.IdRegion)).ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
        */

        //
        List<Domain.Province> listProvinces = _context.Province
            .Include(x => x.Region)
            .ThenInclude(y => y.MacroZone)
            .Where(x => x.Region.Name==region)
            .ToList();
        return MyMapper<Domain.Province, Dto.Province>.MapList(listProvinces);
        
        
        }

    public List<Dto.Province> GetProvincebyMacrozone(string macrozone)
    {
        List<Domain.Province> listProvinces = _context.Province
            .Include(x => x.Region)
                .ThenInclude(r => r.MacroZone)
            .Where(x => x.Region.MacroZone.Name==macrozone)
            .ToList();
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
        Domain.MacroZone macrozone=_context.Region
            .Include(x=>x.MacroZone)
            .Where(x=>x.Name==region)
            .Select(x=>x.MacroZone)
            .FirstOrDefault();
        return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone);
    }

    public Dto.MacroZone GetMacrozoneHavingProvince(string province)
    {
       
            var macrozone = _context.Province
                .Include(x => x.Region)
                .ThenInclude(y => y.MacroZone)
                //.Where(x => x.Name == province)
                //.Select(x => x.Region.MacroZone)
                .FirstOrDefault(x => x.Name == province).Region.MacroZone;
            return MyMapper<Domain.MacroZone, Dto.MacroZone>.Map(macrozone);
        
            
        
    }

    public List<Business.IUtilsManager.MyAtecoClass> GetNActiveIndustriesbyCatandProv(List<string> prov = null, List<string> category = null)
    {

        //ottengo la lista delle province con i nomi passati dalla lista
        List<Dto.Province> provinces;
        if (prov.IsNullOrEmpty()) 
        { 
            provinces= GetAllProvinces();
        }
        else
        {
            provinces = GetProvincesDetails(prov);
        }
        List<Domain.Province> lProvinces = MyMapper<Dto.Province, Domain.Province>.MapList(provinces);

        List<Business.IUtilsManager.MyAtecoClass> result;
        if (category.IsNullOrEmpty())
        {
             result = _context.Industry
                .Include(x => x.Province)
                .Where(x => lProvinces.Contains(x.Province))
                .GroupBy(x => new Tuple<string, string>(x.Province.Name, x.Ateco))
                .Select(x => new Business.IUtilsManager.MyAtecoClass
                (
                    x.Key.Item1,
                    x.Key.Item2,
                    x.Sum(y => y.CountActive)
                )).ToList();

        }
        else
        {
            result = _context.Industry
                .Include(x => x.Province)
                .Where(x => lProvinces
                .Contains(x.Province) && category
                .Contains(x.Ateco))
                .GroupBy(x => new Tuple<string, string>(x.Province.Name, x.Ateco))
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
