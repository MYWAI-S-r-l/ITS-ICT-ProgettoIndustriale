using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigCommodity : IEntityTypeConfiguration<Commodity>
    {

        public void Configure(EntityTypeBuilder<Commodity> entity)
        {

            entity.Property(c => c.Id).IsRequired();
           
            entity.HasKey(c => c.Id);
                        
            entity.HasOne(c => c.Dates).WithMany().HasForeignKey(c => c.IdDates);
            
            entity.Property(c => c.Name).IsRequired();
            
            entity.Property(c => c.ValueUsd).IsRequired();
            
            entity.Property(c => c.Unit).IsRequired();
            
            entity.Property(c => c.IdDates).IsRequired();
            
          

        }

    }
}
