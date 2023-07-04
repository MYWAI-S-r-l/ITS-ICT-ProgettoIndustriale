using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigTernaToken : IEntityTypeConfiguration<TernaToken>
    {
        public void Configure(EntityTypeBuilder<TernaToken> entity)
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
        }
    }
}
