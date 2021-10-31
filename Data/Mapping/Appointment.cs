using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
  {
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
      builder.ToTable(nameof(Appointment), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
      builder.Property(x => x.IsActive).HasDefaultValue(true);
      builder.Property(x => x.IsPrivate).HasDefaultValue(false);
      builder.Property(x => x.InProcess).HasDefaultValue(false);

      builder.HasOne(m => m.User)
      .WithMany(w=> w.Appointment)
      .HasForeignKey(f => f.UserId)
      .HasConstraintName("UserAppointmen_FK")
      .OnDelete(DeleteBehavior.Cascade);

      // builder.HasOne(m => m.Doctor)
      // .WithMany(w=> w.AppointmentDoctor)
      // .HasForeignKey(f => f.DoctorId)
      // .HasConstraintName("DoctorAppointmen_FK")
      // .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(m => m.Department)
      .WithMany()
      .HasForeignKey(f => f.DepartmentId)
      .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(m => m.Sick)
      .WithMany()
      .HasForeignKey(f => f.SickId)
      .OnDelete(DeleteBehavior.Restrict);


        }
  }
}
