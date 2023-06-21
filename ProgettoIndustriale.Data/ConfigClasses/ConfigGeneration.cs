using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigGeneration : IEntityTypeConfiguration<Generation>
    {

        public void Configure(EntityTypeBuilder<Generation> entity)
        {

            entity.Property(g => g.Id).IsRequired();
           
            entity.HasKey(g => g.Id);
            
            entity.HasOne(w => w.Dates).WithMany().HasForeignKey(g => g.IdDates);
            
            entity.Property(g => g.GenerationGhw).IsRequired();
            
            entity.Property(g => g.Type).IsRequired();
            
            entity.Property(g => g.IdDates).IsRequired();



        }

    }
}
