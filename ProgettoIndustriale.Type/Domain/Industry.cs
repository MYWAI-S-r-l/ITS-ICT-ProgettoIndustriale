using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public partial class Industry
    {
        public Industry()
        {
        }

        [Key]
        [Column("ID_industry")]
        public int Id { get; set; }

        [Column("ateco_code")]
        public string Ateco { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("count_active")]
        public int CountActive { get; set; }

        [Column("COD_province")]
        public int IdProvince { get; set; }

        public virtual Province Province { get; set; }
    }
}