using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgettoIndustriale.Data.Mapping;

public class ProvinciaConfiguration : IEntityTypeConfiguration<Type.Domain.Provincia>
{
    public void Configure(EntityTypeBuilder<Type.Domain.Provincia> entity)
    {
        entity.ToTable("Province");
        entity.HasKey(e => new { e.Codice });

    }
}
public class TernaTokenConfiguration : IEntityTypeConfiguration<Type.Domain.TernaToken>
{
    public void Configure(EntityTypeBuilder<Type.Domain.TernaToken> entity)
    {
        entity.ToTable("TernaToken");
        entity.HasKey(e => new { e.Id });

    }
}
