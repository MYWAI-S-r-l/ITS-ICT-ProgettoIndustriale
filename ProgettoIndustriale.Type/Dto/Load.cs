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
        public int idLoad { get; set; }
        public int totalLoadMW { get; set; }
        public float forecastTotalLoadMw { get; set; }
        public Date tblDate { get; set; }
        public  MacroZone tblMacroZone { get; set; }

    }
}
