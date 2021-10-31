using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class DoctorEducationsMapping : IEntityTypeConfiguration<DoctorEducations>
  {
    public void Configure(EntityTypeBuilder<DoctorEducations> builder)
    {
      builder.ToTable(nameof(DoctorEducations), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(m => m.DoctorDetail)
            .WithMany(w => w.DoctorEducations)
            .HasForeignKey(f => f.DoctorDetailId)
            .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
