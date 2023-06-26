using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;


namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigDate: IEntityTypeConfiguration<Date>
    {

        public void Configure (EntityTypeBuilder<Date> entity)

        {

            entity.Property(d => d.Id).IsRequired();

            entity.Property(d => d.DateTime).IsRequired();

            entity.Property(d => d.Year).IsRequired();

            entity.Property(d => d.Month).IsRequired();

            entity.Property(d => d.Day).IsRequired();

            entity.Property(d => d.Time).IsRequired();       

            entity.HasMany(d => d.Weathers).WithOne(a => a.Date).HasForeignKey(d => d.IdDate);

            entity.HasMany(d => d.Commodities).WithOne(a => a.Date).HasForeignKey(d => d.IdDate);

            entity.HasMany(d => d.Generations).WithOne(a => a.Date).HasForeignKey(d => d.IdDate);

            entity.HasMany(d => d.Loads).WithOne().HasForeignKey(d => d.IdDate);

            entity.HasMany(d => d.Prices).WithOne().HasForeignKey(d => d.IdDate);

        }

    }
}
