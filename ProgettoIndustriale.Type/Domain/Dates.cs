using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Dates
    {
        public Dates() { }

        public int Id { get; set; }

        public DateTime dateTime { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public TimeOnly time { get; set; }

        public virtual ICollection<Weather> Weathers { get; set; }

        public virtual ICollection<Commodity> Commodities { get; set; }

        public virtual ICollection<Generation> Generations { get; set; }

        public virtual ICollection<Load> Loads { get; set; }

        public virtual ICollection<Price> Prices { get; set; }



    }
}
