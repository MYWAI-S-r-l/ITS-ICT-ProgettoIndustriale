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