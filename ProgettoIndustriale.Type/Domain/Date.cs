﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Date
    {
        public Date() { }
        [Column("ID_date")]
        public int Id { get; set; }
        [Column("date_time")]
        public DateTime DateTime { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("month")]
        public int Month { get; set; }
        [Column("day")]
        public int Day { get; set; }
        [Column("time")]
        public TimeSpan Time { get; set; }

        public virtual ICollection<Weather> Weathers { get; set; }

        public virtual ICollection<Commodity> Commodities { get; set; }

        public virtual ICollection<Generation> Generations { get; set; }

        public virtual ICollection<Load> Loads { get; set; }

        public virtual ICollection<Price> Prices { get; set; }



    }
}
