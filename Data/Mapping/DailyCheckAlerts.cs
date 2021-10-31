using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class DailyCheckAlertsMapping : IEntityTypeConfiguration<DailyCheckAlerts>
    {
        public void Configure(EntityTypeBuilder<DailyCheckAlerts> builder)
        {
            builder.ToTable(nameof(DailyCheckAlerts), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(m => m.DailyCheck)
            .WithMany(w => w.DailyCheckAlerts)
            .HasForeignKey(f => f.DailyCheckId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        }
    }
}
