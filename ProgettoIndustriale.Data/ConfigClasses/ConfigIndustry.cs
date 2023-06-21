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
    public class ConfigIndustry : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> entity)
        {

            entity.Property(i => i.Id).IsRequired();
            entity.HasKey(i => i.Id);

            entity.HasOne(i => i.Province).WithMany(a => a.Industries).HasForeignKey(p => p.IdProvince);//collection in regione

            entity.Property(p => p.IdProvince).HasColumnName("COD_province");

            entity.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(45)
            .IsUnicode(false);

            entity.Property(i => i.CountActive)
            .IsRequired();

        }
    }
}
