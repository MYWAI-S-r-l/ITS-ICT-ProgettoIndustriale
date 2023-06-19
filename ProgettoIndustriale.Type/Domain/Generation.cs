using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Domain
{
    public class Generation
    {
        public Generation() { }

        public int Id { get; set; }

        public double GenerationGhw { get; set; }

        public string Type { get; set; }

        public int IdDates { get; set; }

        public virtual Dates Dates { get; set; }

    }
}
