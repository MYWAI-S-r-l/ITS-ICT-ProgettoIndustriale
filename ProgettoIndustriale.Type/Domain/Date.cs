using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public class Date
    {
        public Date()
        { }

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

        [Column("hour")]
        public int Hour { get; set; }

        public virtual ICollection<Weather>? Weathers { get; set; }

        public virtual ICollection<Commodity>? Commodities { get; set; }

        public virtual ICollection<Generation>? Generations { get; set; }

        public virtual ICollection<Load>? Loads { get; set; }

        public virtual ICollection<Price>? Prices { get; set; }
    }
}