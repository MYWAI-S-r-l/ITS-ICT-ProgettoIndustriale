using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
public interface IRegionManager
{
    Dto.Region? GetRegion(int id);

    List<Dto.Region> GetAllRegions();
}

