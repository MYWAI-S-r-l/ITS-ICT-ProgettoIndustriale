using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigLoad : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> entity)
        {
            //Proprietà dei vari campi, chiave primaria ed esterna.
            //Tutti i campi sono richiesti, per poter verificare eventuali problemi direttamente dal codice

            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            entity.HasKey(e => e.Id );
            entity.Property(e => e.TotalLoadMW).IsRequired();
            entity.Property(e => e.ForecastTotalLoadMw).IsRequired();
            entity.HasOne(e => e.MacroZone).WithMany(c => c.Loads).HasForeignKey(e => e.IdMacroZone);
            entity.Property(w => w.IdMacroZone).HasColumnName("COD_macrozone");
            entity.HasOne(e => e.Date).WithMany(c => c.Loads).HasForeignKey(e => e.IdDate);
            entity.Property(e => e.IdDate).HasColumnName("COD_date");

            


        }
    }
}