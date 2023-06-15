using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ModelBuilder
{
    public class ConfigureMacroZone : IEntityTypeConfiguration<MacroZone>
    {
        public void Configure(EntityTypeBuilder<MacroZone> entity)
        {
            //Proprietà dei vari campi, chiave primaria ed esterna.
            //Tutti i campi sono richiesti, per poter verificare eventuali problemi direttamente dal codice

            entity.Property(e => e.Id).IsRequired();
            entity.HasKey(e => e.Id );
            entity.Property(e=>e.Name).IsRequired();
            entity.Property(e=>e.BiddingZone).IsRequired();
            entity.HasMany(e=>e.Regions).WithOne().HasForeignKey(e=>e.IdMacroZone);
            
        }
    }
}