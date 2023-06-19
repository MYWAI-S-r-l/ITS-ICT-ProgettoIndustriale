using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Commodity
    {
        public Commodity() { }

        public int Id { get; set; }

        public  string Name { get; set; }

        public double ValueUsd { get; set; }

        public string Unit { get; set; }

        public int IdDates { get; set; }

        public virtual Dates Dates { get; set; }

    }
}
