using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Data.ConfigClasses
{
    public class ConfigWeather : IEntityTypeConfiguration<Weather>
    {

        public void Configure(EntityTypeBuilder<Weather> entity)
        {

            entity.Property(w => w.Id).IsRequired();
           
            entity.HasKey(w => w.Id);
            
            entity.HasOne(w => w.Province).WithMany(w => w.Weathers).HasForeignKey(p => p.IdProvince);
            
            entity.HasOne(w => w.Date).WithMany(w => w.Weathers).HasForeignKey(p => p.IdDate);

            entity.Property(w => w.IdProvince).HasColumnName("COD_province");

            entity.Property(w => w.IdDate).HasColumnName("COD_date");

            entity.Property(w => w.Temperature).IsRequired();
            
            entity.Property(w => w.Dewpoint).IsRequired();

            entity.Property(w => w.RelativeHumidity).IsRequired().HasColumnName("relativehumidity_2m_percent");
            
            entity.Property(w => w.ApparentTemperature).IsRequired();
            
            entity.Property(w => w.Cloudcover).IsRequired();
            
            entity.Property(w => w.WindSpeed10m).IsRequired();
            
            entity.Property(w => w.WindSpeed80m).IsRequired();
            
            entity.Property(w => w.SurfacePressure).IsRequired();
            
            entity.Property(w => w.Rain).IsRequired();
            
            entity.Property(w => w.Snowfall).IsRequired();
            
            entity.Property(w => w.Shower).IsRequired();
            
            entity.Property(w => w.Precipitation).IsRequired();
            
            entity.Property(w => w.SnowDepth).IsRequired();
            
            entity.Property(w => w.IsDay).IsRequired();
            
            entity.Property(w => w.IdProvince).IsRequired();
            
            entity.Property(w => w.IdDate).IsRequired();







        }

    }
}
