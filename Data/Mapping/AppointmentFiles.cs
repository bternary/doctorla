using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class AppointmentFilesMapping : IEntityTypeConfiguration<AppointmentFiles>
  {
    public void Configure(EntityTypeBuilder<AppointmentFiles> builder)
    {
      builder.ToTable(nameof(AppointmentFiles), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
      builder.Property(x => x.IsActive).HasDefaultValue(true);
      builder.HasOne(m => m.Appointment)
     .WithMany(w => w.AppointmentFiles)
     .HasForeignKey(f => f.AppointmentId)
     .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
