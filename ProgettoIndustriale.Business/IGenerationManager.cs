using System.Collections.Generic;
using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *             Commodity
 * ************************************/


public interface IGenerationManager
{
    public List<Dto.Generation> getAllGenerations();
    public List<Dto.Generation> getGenerationsbyDates(DateTime startDate, DateTime endDate);

    
}