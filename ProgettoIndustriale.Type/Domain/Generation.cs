using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Generation
    {
        public Generation() { }
        [Column("ID_generation")]
        public int Id { get; set; }
        [Column("Generation_ghw")]
        public double GenerationGhw { get; set; }
        [Column("type")]
        public string Type { get; set; }

        public int IdDates { get; set; }

        public virtual Date Dates { get; set; }

    }
}
