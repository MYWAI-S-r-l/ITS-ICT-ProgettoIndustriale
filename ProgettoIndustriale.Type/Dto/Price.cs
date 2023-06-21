using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class Price
    {
        public Price() { }
        public int idPrice { get; set; }
        public float basePriceEur { get; set; }
        public  float incentiveComponentEur { get; set; }
        public float unbalancePriceEur { get; set; }
        public MacroZone tblMacroZone { get; set; }
        public Date tblDate { get; set; }

    }
}
