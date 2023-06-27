using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface ILoadManager
{
    Dto.Load? GetLoad(int id);

    List<Dto.Load> GetAllLoads();
}

