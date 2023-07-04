using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigApiCallsLogs : IEntityTypeConfiguration<ApiCallsLogs>
    {
        public void Configure(EntityTypeBuilder<ApiCallsLogs> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ApiCallName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CallFrequency)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.LastSuccessfulRun);
        }
    }
}
