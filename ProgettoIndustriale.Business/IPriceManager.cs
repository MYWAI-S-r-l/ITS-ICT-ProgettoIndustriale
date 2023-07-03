using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *              Price
 * ************************************/


public interface IPriceManager
{

    public List<Dto.Price> GetAllPrice();
    public List<Dto.Price> GetPricebyDate(DateTime startDate, DateTime endDate);
    public List<Dto.Price> GetPricebyMacrozone(List<string> macrozone);
    public List<Dto.Price> GetPricebyProvinceDate(List<string> macrozone, DateTime startDate, DateTime endDate);

}