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

    public List<Dto.Price> GetAllPrices();
    public List<Dto.Price> GetPricesbyDates(DateTime startDate, DateTime endDate);
    public List<Dto.Price> GetPricesbyMacrozones(List<string> macrozone);
    public List<Dto.Price> GetPricesbyMacrozonesDates(List<string> macrozone, DateTime startDate, DateTime endDate);

}