using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class NotifyWarningMapping : IEntityTypeConfiguration<NotifyWarning>
  {
    public void Configure(EntityTypeBuilder<NotifyWarning> builder)
    {
      builder.ToTable(nameof(NotifyWarning), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
        builder.HasOne(m => m.User)
        .WithMany(w => w.NotifyWarnings)
        .HasForeignKey(f => f.UserId)
        .HasConstraintName("notifyuserFrgn");
        builder.HasOne(m => m.Department)
        .WithMany(w => w.NotifyWarnings)
        .HasForeignKey(f => f.DepartmentId)
        .HasConstraintName("departmentFrgn");
        }
  }
}
