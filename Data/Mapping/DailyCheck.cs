using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class DailyCheckMapping : IEntityTypeConfiguration<DailyCheck>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DailyCheck> builder)
        {
            builder.ToTable(nameof(DailyCheck), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
     
            builder.HasOne(m => m.User)
            .WithMany(w => w.DailyCheck)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("userFrgn")
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Nurse)
            .WithMany(w => w.NurseDailyCheck)
            .HasForeignKey(f => f.NurseId)
            .HasConstraintName("nurseFrgn");
        }
    }
}
