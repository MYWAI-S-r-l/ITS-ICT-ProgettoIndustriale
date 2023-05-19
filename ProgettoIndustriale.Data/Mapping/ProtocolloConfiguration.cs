using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgettoIndustriale.Data.Mapping;

public class EnteConfiguration : IEntityTypeConfiguration<Type.Domain.Ente>
{
    public void Configure(EntityTypeBuilder<Type.Domain.Ente> entity)
    {
        entity.ToTable("Enti");
        entity.HasKey(e => new { e.Id });

    }
}

public class ProvinciaConfiguration : IEntityTypeConfiguration<Type.Domain.Provincia>
{
    public void Configure(EntityTypeBuilder<Type.Domain.Provincia> entity)
    {
        entity.ToTable("Province");
        entity.HasKey(e => new { e.Codice});

    }
}