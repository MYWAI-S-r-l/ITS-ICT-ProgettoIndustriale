using Microsoft.AspNetCore.Mvc;
using dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    public partial class CommodityController 
    {
        [HttpGet("getAllCommodities")]
        public IEnumerable<dto.Commodity> getAllCommodities()
        {
            return _commodityManager.getAllCommodities();
        }


       

        [HttpGet("getCommoditybyDates")]
        public IEnumerable<dto.Commodity> getCommodityByDates(DateTime startDate, DateTime endDate)
        {
            return _commodityManager.getComoditybyDates(startDate, endDate);
        }
        

    }
}
