using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Type.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigProvince:IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> entity)
        {
            
                entity.Property(p => p.Id).IsRequired().HasValueGenerator<GuidValueGenerator>();
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Region).WithMany(a => a.Provinces).HasForeignKey(p => p.IdRegion).HasConstraintName("fk_Province_Region1");//collection in regione

                entity.HasMany(p => p.Industries).WithOne().HasForeignKey(p => p.IdProvince);

                entity.Property(p => p.IdRegion).HasColumnName("COD_region");


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
