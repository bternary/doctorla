using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class CityMapping : IEntityTypeConfiguration<City>
  {
    public void Configure(EntityTypeBuilder<City> builder)
    {
      builder.ToTable(nameof(City), "dbo");
      builder.HasKey(o => o.Id);
          builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
      builder.HasOne(m => m.Country)
      .WithMany(w => w.Cities)
      .HasForeignKey(f => f.CountryId)
      .OnDelete(DeleteBehavior.Restrict)
      .IsRequired();
    }
  }
}
