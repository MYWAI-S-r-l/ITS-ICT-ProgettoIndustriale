using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface ICommodityManager
{
    Dto.Commodity? GetCommodity(int id);

    List<Dto.Commodity> GetAllCommodities();
}

