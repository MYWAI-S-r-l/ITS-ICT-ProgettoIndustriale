using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public class Generation
    {
        public Generation()
        { }

        [Column("ID_generation")]
        public int Id { get; set; }

        [Column("Generation_ghw")]
        public double GenerationGhw { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        public int IdDate { get; set; }

        public virtual Date? Date { get; set; }
    }
}