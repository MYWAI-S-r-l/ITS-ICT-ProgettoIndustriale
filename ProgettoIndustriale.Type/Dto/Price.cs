using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class Price
    {
        public Price() { }

        public int Id { get; set; }
        public float basePriceEur { get; set; }
        public float incentiveComponentEur { get; set; }
        public float unbalancePriceEur { get; set; }
        //public string macrozone { get; set; }
        public MacroZone? MacroZone { get; set; }
        //public string date { get; set; }
        public Date Date { get; set; }
        [JsonPropertyName("daily_prices")]
        public List<DailyPrice> DailyPrice { get; set; }
    }
}