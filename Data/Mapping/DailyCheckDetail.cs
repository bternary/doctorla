using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class DailyCheckDetailMapping : IEntityTypeConfiguration<DailyCheckDetail>
    {
        public void Configure(EntityTypeBuilder<DailyCheckDetail> builder)
        {
            builder.ToTable(nameof(DailyCheckDetail), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(w => w.DailyCheck)
                .WithMany(k => k.DailyCheckDetail)
                .HasForeignKey(f => f.DailyCheckId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.ValuesTitle)
            .WithMany(k => k.DailyCheckDetail)
            .HasForeignKey(x=>x.ValuesTitleId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(w => w.Values)
            .WithOne(x=>x.DailyCheckDetail)
            .HasForeignKey(x => x.DailyCheckDetailId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
