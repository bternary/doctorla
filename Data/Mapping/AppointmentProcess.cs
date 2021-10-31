using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class AppointmentProcessMapping : IEntityTypeConfiguration<AppointmentProcess>
  {
    public void Configure(EntityTypeBuilder<AppointmentProcess> builder)
    {
      builder.ToTable(nameof(AppointmentProcess), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);

      builder.HasOne(m => m.Appointment)
     .WithMany(w => w.AppointmentProcess)
     .HasForeignKey(f => f.AppointmentId)
     .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
