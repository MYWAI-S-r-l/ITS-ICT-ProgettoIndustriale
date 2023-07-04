using System.Collections.Generic;
using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *               Load 
 * ************************************/


public interface ILoadManager
{
    public List<Dto.Load> getAllLoads();
    public List<Dto.Load> getLoadsbyFilter(string macrozone, DateTime startDate, DateTime endDate);
    public List<Dto.Load> getLoadbyMacrozone(List<string> nameMacroZone);
    public List<Dto.Load> getloadbyDates(DateTime startDate, DateTime endDate);


   
    
}