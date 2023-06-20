﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Load
    {
        public Load() { }
        [Column("ID_load")]
        public int Id { get; set; }
        [Column("total_load_MW")]
        public int TotalLoadMW { get; set; }
        [Column("forecast_total_load_MW")]
        public float ForecastTotalLoadMw { get; set; }
        [Column("COD_Date")]
        public int IdDate { get; set; }
        public int IdMacroZone { get; set; }
        public virtual Dates Date { get; set; }
        public virtual MacroZone MacroZone { get; set; }

    }
}
