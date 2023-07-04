using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigPrice : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> entity)
        {
            //Proprietà dei vari campi, chiave primaria ed esterna.
            //Tutti i campi sono richiesti, per poter verificare eventuali problemi direttamente dal codice

            entity.Property(e => e.Id).IsRequired().HasValueGenerator<GuidValueGenerator>();
            entity.Property(e => e.BasePriceEur).IsRequired();
            entity.Property(e => e.IncentiveComponentEur).IsRequired();
            entity.Property(e => e.UnbalancePriceEur).IsRequired();
            entity.HasKey(e => e.Id );
            entity.HasOne(e => e.MacroZone).WithMany().HasForeignKey(e => e.IdMacroZone);
            entity.HasOne(e => e.Date).WithMany().HasForeignKey(e => e.IdDate);
        }
    }
}