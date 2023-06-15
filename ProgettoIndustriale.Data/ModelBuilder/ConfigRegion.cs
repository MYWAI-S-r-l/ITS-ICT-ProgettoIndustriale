﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Type.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ProgettoIndustriale.Data.ModelBuilder
{
    public class ConfigRegion : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            
                entity.Property(p => p.Id).IsRequired();
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

                entity.HasOne(p => p.Macrozone).WithMany().HasForeignKey(m => m.IdMacrozone);//collection in regione
                
                entity.HasMany(p=>p.Provinces).WithOne().HasForeignKey(p => p.IdRegion);

        }


    }
}