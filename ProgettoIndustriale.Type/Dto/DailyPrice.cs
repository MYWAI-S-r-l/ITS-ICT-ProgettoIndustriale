using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class DailyPrice
    {
        public DailyPrice() { }
        [JsonPropertyName("base_price_EURxMWh")]
        public string BasePriceEur { get; set; }
        [JsonPropertyName("incentive_component_EURxMWh")]
        public string IncentiveComponentEur { get; set; }
        [JsonPropertyName("unbalance_price_EURxMWh")]
        public string UnbalancePriceEur { get; set; }
        [JsonPropertyName("macrozone")]
        public string Macrozone { get; set; }
        [JsonPropertyName("reference_date")]
        public string Date { get; set; }
    }
}
