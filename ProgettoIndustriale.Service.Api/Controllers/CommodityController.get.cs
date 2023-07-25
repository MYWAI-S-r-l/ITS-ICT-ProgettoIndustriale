using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using dto = ProgettoIndustriale.Type.Dto;


namespace ProgettoIndustriale.Service.Api.Controllers
{
    public partial class CommodityController
    {
        [HttpGet("getAllCommodities")]
        public IEnumerable<dto.Commodity> getAllCommodities()
        {
            
            return  _commodityManager.getAllCommodities();
                        
            
        }

        [HttpGet("getCommoditybyDates")]
        public object getCommodityByDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
        {
            if (CheckDate.TryDateCheck(startDate, endDate))
            {
                return _commodityManager.getComoditybyDates(startDate, endDate);
            }
                
            return BadRequest(CheckDate.errorMessage);
            
        }
    }
}