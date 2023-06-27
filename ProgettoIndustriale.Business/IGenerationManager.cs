using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IGenerationManager
{
    Dto.Generation? GetGeneration(int id);
   
    List<Dto.Generation> GetAllGenerations();
}

