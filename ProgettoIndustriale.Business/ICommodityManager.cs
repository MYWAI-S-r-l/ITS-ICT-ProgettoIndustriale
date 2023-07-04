using System.Collections.Generic;
using ProgettoIndustriale.Type;

using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *             Commodity
 * ************************************/


public interface ICommodityManager
{
    public List<Dto.Commodity> getAllCommodities();
    public List<Dto.Commodity> getComoditybyDates(DateTime startDate, DateTime endDate);
    
    
}