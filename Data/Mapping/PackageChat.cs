using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class PackageChatMapping : IEntityTypeConfiguration<PackageChat>
  {
    public void Configure(EntityTypeBuilder<PackageChat> builder)
    {
      builder.ToTable(nameof(PackageChat), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Date).HasDefaultValue(DateTime.Now);
      builder.HasOne(m => m.DailyCheck)
      .WithMany(w => w.PackageChat)
      .HasForeignKey(f => f.DailyCheckId)
      .OnDelete(DeleteBehavior.Restrict)
      .IsRequired();
    }
  }
}
