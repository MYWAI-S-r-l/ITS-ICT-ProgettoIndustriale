using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IIndustryManager
{
    Dto.Industry? GetIndustry(int id);
   
    List<Dto.Industry> GetAllIndustries();
}

