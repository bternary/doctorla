using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class CountyMapping : IEntityTypeConfiguration<County>
  {
    public void Configure(EntityTypeBuilder<County> builder)
    {
      builder.ToTable(nameof(County), "dbo");
      builder.Property(x => x.IsActive).HasDefaultValue(true);
      builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
      builder.HasOne(m => m.City)
      .WithMany(w => w.Counties)
      .HasForeignKey(f => f.CityId)
      .OnDelete(DeleteBehavior.Restrict)
      .IsRequired();
    }
  }
}
