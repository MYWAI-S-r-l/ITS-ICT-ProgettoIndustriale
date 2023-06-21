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
                        
            entity.HasOne(c => c.Date).WithMany().HasForeignKey(c => c.IdDate);
            
            entity.Property(c => c.Name).IsRequired();
            
            entity.Property(c => c.ValueUsd).IsRequired();
            
            entity.Property(c => c.Unit).IsRequired();
            
            entity.Property(c => c.IdDate).IsRequired();
            
          

        }

    }
}
