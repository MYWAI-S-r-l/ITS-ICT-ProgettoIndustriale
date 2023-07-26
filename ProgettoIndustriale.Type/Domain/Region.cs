using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public partial class Region
    {
        public Region()
        {
        }

        [Column("ID_region")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        public int IdMacroZone { get; set; }

        public virtual MacroZone? MacroZone { get; set; }
        public virtual ICollection<Province>? Provinces { get; set; }
    }
}