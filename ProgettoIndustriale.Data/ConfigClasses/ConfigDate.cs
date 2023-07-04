using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProgettoIndustriale.Type.Domain;


namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigDate: IEntityTypeConfiguration<Date>
    {

        public void Configure (EntityTypeBuilder<Date> entity)

        {

            entity.Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(d => d.DateTime).IsRequired();

            entity.Property(d => d.Year).IsRequired();

            entity.Property(d => d.Month).IsRequired();

            entity.Property(d => d.Day).IsRequired();

            entity.Property(d => d.Hour).IsRequired();       


            entity.HasMany(d => d.Weathers).WithOne(a => a.Date).HasForeignKey(d => d.IdDate).HasConstraintName("COD_date");

            entity.HasMany(d => d.Commodities).WithOne(a => a.Date).HasForeignKey(d => d.IdDate).HasConstraintName("COD_date");

            entity.HasMany(d => d.Generations).WithOne(a => a.Date).HasForeignKey(d => d.IdDate).HasConstraintName("COD_date");

            entity.HasMany(d => d.Loads).WithOne(x=>x.Date).HasForeignKey(d => d.IdDate).HasConstraintName("COD_date");

            entity.HasMany(d => d.Prices).WithOne(x => x.Date).HasForeignKey(d => d.IdDate).HasConstraintName("COD_date");


        }

    }
}
