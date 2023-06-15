﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ModelBuilder
{
    public class ConfigWeather : IEntityTypeConfiguration<Weather>
    {

        public void Configure(EntityTypeBuilder<Weather> entity)
        {

            entity.Property(w => w.Id).IsRequired();
           
            entity.HasKey(w => w.Id);
            
            entity.HasOne(w => w.Province).WithMany().HasForeingKey<Province>(p => p.IdProvince);
            
            entity.HasOne(w => w.Dates).WithMany().HasForeignKey(p => p.IdDates);
            
            entity.Property(w => w.Temperature).IsRequired();
            
            entity.Property(w => w.Dewpoint).IsRequired();
            
            entity.Property(w => w.RelativeHumidity).IsRequired();
            
            entity.Property(w => w.ApparentTemperature).IsRequired();
            
            entity.Property(w => w.Cloudcover).IsRequired();
            
            entity.Property(w => w.WindSpeed10m).IsRequired();
            
            entity.Property(w => w.WindSpeed80m).IsRequired();
            
            entity.Property(w => w.SurfacePressure).IsRequired();
            
            entity.Property(w => w.Rain).IsRequired();
            
            entity.Property(w => w.Snowfall).IsRequired();
            
            entity.Property(w => w.Showers).IsRequired();
            
            entity.Property(w => w.Precipitation).IsRequired();
            
            entity.Property(w => w.SnowDepth).IsRequired();
            
            entity.Property(w => w.IsDay).IsRequired();
            
            entity.Property(w => w.IdProvince).IsRequired();
            
            entity.Property(w => w.IdDates).IsRequired();





        }

    }
}