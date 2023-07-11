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
    public class ConfigRegion : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            
                entity.Property(p => p.Id).IsRequired().HasColumnName("ID_region").ValueGeneratedOnAdd();
            entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");


                entity.HasOne(p => p.MacroZone).WithMany(a => a.Regions).HasForeignKey(m => m.IdMacroZone);//collection in regione
                
                entity.HasMany(p=>p.Provinces).WithOne(a=>a.Region).HasForeignKey(p => p.IdRegion);

                entity.Property(p => p.IdMacroZone).HasColumnName("COD_macrozone");
                

        }


    }
}
