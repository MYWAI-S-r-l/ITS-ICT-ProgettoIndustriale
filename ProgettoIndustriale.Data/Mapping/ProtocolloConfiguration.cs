using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgettoIndustriale.Data.Mapping;

public class ProvinciaConfiguration : IEntityTypeConfiguration<Type.Domain.Provincia>
{
    public void Configure(EntityTypeBuilder<Type.Domain.Provincia> entity)
    {
        entity.ToTable("Province");
        entity.HasKey(e => new { e.Codice});

    }
}