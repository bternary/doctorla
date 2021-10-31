using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class DoctorExperiencesMapping : IEntityTypeConfiguration<DoctorExperiences>
  {
    public void Configure(EntityTypeBuilder<DoctorExperiences> builder)
    {
      builder.ToTable(nameof(DoctorExperiences), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(m => m.DoctorDetail)
            .WithMany(w => w.DoctorExperiences)
            .HasForeignKey(f => f.DoctorDetailId)
            .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
