using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public class Commodity
    {
        public Commodity()
        { }

        [Column("ID_commodity")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("value_USD")]
        public double ValueUsd { get; set; }

        [Column("unit")]
        public string? Unit { get; set; }
        [Column("COD_date")]
        public int IdDate { get; set; }

        public virtual Date? Date { get; set; }
    }
}