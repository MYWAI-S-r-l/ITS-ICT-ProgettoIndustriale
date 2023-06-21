using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Type.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigProvince:IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> entity)
        {
            
                entity.Property(p => p.Id).IsRequired();
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Region).WithMany().HasForeignKey(p => p.IdRegion);//collection in regione
 

                entity.HasMany(p => p.Industries).WithOne().HasForeignKey(p => p.IdProvince);



                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                    entity.Property(p => p.Longitude)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                    entity.Property(p => p.Latitude)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);


                    entity.Property(p => p.Surface)
                           .IsRequired();

                    entity.Property(p => p.Altitude)
                           .IsRequired();

                    entity.Property(p => p.Residents)
                           .IsRequired();

                    entity.Property(p => p.PopulationDensity)
                           .IsRequired();

                    entity.Property(p => p.NCities)
                           .IsRequired();


            
        }


    }
}
