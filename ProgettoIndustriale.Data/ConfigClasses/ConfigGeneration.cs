using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigGeneration : IEntityTypeConfiguration<Generation>
    {

        public void Configure(EntityTypeBuilder<Generation> entity)
        {

            entity.Property(g => g.Id).IsRequired().HasValueGenerator<GuidValueGenerator>();

            entity.HasKey(g => g.Id);
            
            entity.HasOne(w => w.Date).WithMany(a => a.Generations).HasForeignKey(g => g.IdDate);
            
            entity.Property(g => g.GenerationGhw).IsRequired();

            entity.Property(d => d.IdDate).HasColumnName("COD_date");


            entity.Property(g => g.Type).IsRequired();
            
            entity.Property(g => g.IdDate).IsRequired();



        }

    }
}
