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
            if (startDate > endDate)
            {
                return BadRequest("La data di inizio non può essere successiva alla data di fine");
            }

            if (startDate > DateTime.Now)
            {
                return BadRequest("La data di inizio non può essere futura.");
            }
            if (startDate == default || endDate == default)
            {
                return BadRequest("Inserire data");
            }

            return _commodityManager.getComoditybyDates(startDate, endDate);
        }
    }
}