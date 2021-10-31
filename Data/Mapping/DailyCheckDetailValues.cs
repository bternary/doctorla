using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class DailyCheckDetailValuesMapping : IEntityTypeConfiguration<DailyCheckDetailValues>
    {
        public void Configure(EntityTypeBuilder<DailyCheckDetailValues> builder)
        {
            builder.ToTable(nameof(DailyCheckDetailValues), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(w => w.DailyCheckDetail)
                .WithMany(k => k.Values)
                .HasForeignKey(f => f.DailyCheckDetailId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
