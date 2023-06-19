using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Commodity
    {
        public Commodity() { }
        [Column("ID_commodity")]
        public int Id { get; set; }
        [Column("name")]
        public  string Name { get; set; }
        [Column("value_USD")]
        public double ValueUsd { get; set; }
        [Column("unit")]
        public string Unit { get; set; }

        public int IdDates { get; set; }

        public virtual Dates Dates { get; set; }

    }
}
