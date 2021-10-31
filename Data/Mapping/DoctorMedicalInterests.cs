using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class DoctorMedicalInterestsMapping : IEntityTypeConfiguration<DoctorMedicalInterests>
  {
    public void Configure(EntityTypeBuilder<DoctorMedicalInterests> builder)
    {
      builder.ToTable(nameof(DoctorEducations), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(m => m.DoctorDetail)
            .WithMany(w => w.DoctorMedicalInterests)
            .HasForeignKey(f => f.DoctorDetailId)
            .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
