using System.Collections.Generic;
using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *               Date
 *                &
 *              Province 
 * ************************************/


public interface IUtilsManager
{
    public List<Dto.Province> GetAllProvinces();
    public List<Dto.Province> GetProvincebyMacrozone(string macrozone);
    public List<Dto.Province> GetProvincebyRegion(List<string> regions);//nome
}