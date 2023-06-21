﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Data.ModelBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ProgettoIndustriale.Type;
public partial class ProgettoIndustrialeContext : DbContext
{
    private readonly StreamWriter _logStream = new StreamWriter("mylog.txt", append: true); //TODO: prendere path del log da config

    public ProgettoIndustrialeContext()
    {
    }

    public ProgettoIndustrialeContext(DbContextOptions<ProgettoIndustrialeContext> options)
        : base(options)
    {
    }

  
    //-----
    public virtual DbSet<Price> Price { get; set; }
    public virtual DbSet<Load> Load { get; set; }
    public virtual DbSet<MacroZone> MacroZone { get; set; }
    //------
    public virtual DbSet<Province> Province{ get; set; }
    public virtual DbSet<Region> Region { get; set; }
    public virtual DbSet<Industry> Industry { get; set; }

    //-----

    public virtual DbSet<Weather> Weather { get; set; }

    public virtual DbSet<Dates> Dates { get; set; }

    //-----

    public virtual DbSet<Commodity> Commodity { get; set; }

    public virtual DbSet<Generation> Generation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Sono stati creati dei file di configurazione nella cartella "ModelBuilder" per avere più ordine.

        modelBuilder.ApplyConfiguration(new ConfigureLoad());
        modelBuilder.ApplyConfiguration(new ConfigurePrice());
        modelBuilder.ApplyConfiguration(new ConfigureMacroZone());
        modelBuilder.ApplyConfiguration(new ConfigProvince());
        modelBuilder.ApplyConfiguration(new ConfigRegion());
        modelBuilder.ApplyConfiguration(new ConfigIndustry());
        modelBuilder.ApplyConfiguration(new ConfigCommodity());
        modelBuilder.ApplyConfiguration(new ConfigGeneration());



   
    public virtual DbSet<Provincia> Province{ get; set; }
    public virtual DbSet<TernaToken> TernaToken { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Ente>(entity =>
        //{
        //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
        //    entity.HasKey(e => e.Id);
            
        //    entity.Property(e => e.Nome)
        //        .HasMaxLength(256)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Sigla)
        //        .IsRequired()
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.IsDeleted);

        //    entity.Property(e => e.Descrizione)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //});
        //OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<TernaToken>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasKey(e => e.Id);

            entity.Property(e => e.AccessToken)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TokenType)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.AddedTime);
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(_logStream.WriteLine).EnableSensitiveDataLogging().EnableDetailedErrors();
    }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }

    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        await _logStream.DisposeAsync();
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
