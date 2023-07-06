using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class Load
    {
        public Load() { }
        public int Id { get; set; }
        public int totalLoadMW { get; set; }
        public float forecastTotalLoadMw { get; set; }
        public Date Date { get; set; }
        public  MacroZone MacroZone { get; set; }

    }
}
