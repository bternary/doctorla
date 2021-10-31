using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class DoctorScientificMembershipMapping : IEntityTypeConfiguration<DoctorScientificMembership>
  {
    public void Configure(EntityTypeBuilder<DoctorScientificMembership> builder)
    {
      builder.ToTable(nameof(DoctorScientificMembership), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(m => m.DoctorDetail)
            .WithMany(w => w.DoctorScientificMembership)
            .HasForeignKey(f => f.DoctorDetailId)
            .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
