using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Load
    {
        public Load() { }
        
        public int Id { get; set; }
        public int TotalLoadMW { get; set; }
        public float ForecastTotalLoadMw { get; set; }
        public int IdDate { get; set; }
        public int IdMacroZone { get; set; }
        public virtual Date Date { get; set; }
        public virtual MacroZone MacroZone { get; set; }

    }
}
