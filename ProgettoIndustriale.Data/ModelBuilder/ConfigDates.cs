using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Data.ModelBuilder
{
    public class ConfigDates(EntityTypeBuilder<Dates> entity)
    {

        public void Configure (EntityTypeBuilder<Dates> entity)

        {

            entity.Property(d => d.Id).IsRequired();

            entity.Property(d => d.DateTime).IsRequired();

            entity.Property(d => d.Year).IsRequired();

            entity.Property(d => d.Month).IsRequired();

            entity.Property(d => d.Day).IsRequired();

            entity.Property(d => d.Time).IsRequired();

            entity.Property(d => d.TimeOnly).IsRequired();

            entity.HasOne(d => d.Weathers).WithMany().HasForeignKey(d => d.Weathers);

            entity.HasOne(d => d.Commodities).WithMany().HasForeignKey(d => d.Commodities);

            entity.HasOne(d => d.Generations).WithMany().HasForeignKey(d => d.Generations);

            entity.HasOne(d => d.Loads).WithMany().HasForeignKey(d => d.Loads);

            entity.HasOne(d => d.Prices).WithMany().HasForeignKey(d => d.Prices);

        }

    }
}
