using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class PriceController
{
    [HttpPost("getPricesbyMacrozones")]
    public object GetPricesbyMacrozones([BindRequired] List<string> macrozone)
    {
        if (macrozone[0] == "string" || macrozone[0] == "")
        {
            _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "GetPricesbyMacrozones() inserire almeno una macrozone");

            return BadRequest("Inserire almeno una macrozone");
        }
        return _priceManager.GetPricesbyMacrozones(macrozone);
    }

    [HttpPost("getPricesbyMacrozonesDates")]
    public object GetPricesbyMacrozonesDates([BindRequired] List<string> macrozone, [BindRequired] DateTime startDate = default, [BindRequired] DateTime endDate = default)
    {
        if (macrozone[0] == "string"|| macrozone[0] == "")
        {
            _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getPricesbyMacrozonesDates() inserire almeno una macrozone");

            return BadRequest("Inserire almeno una macrozone");
        }
        if (CheckDate.TryDateCheck(startDate, endDate))
        {
            return _priceManager.GetPricesbyMacrozonesDates(macrozone, startDate, endDate);
        }
        else
        {
            _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getPricesbyMacrozonesDates() " + CheckDate.errorMessage);

            return new BadRequestObjectResult(CheckDate.errorMessage);
        }

        
    }
}