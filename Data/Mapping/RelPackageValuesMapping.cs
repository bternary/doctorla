using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class RelPackageValuesMapping : IEntityTypeConfiguration<RelPackageValues>
    {
        public void Configure(EntityTypeBuilder<RelPackageValues> builder)
        {
            builder.ToTable(nameof(RelPackageValues), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IUser).HasDefaultValue(0);
            builder.HasOne(o => o.Package)
            .WithMany(w => w.RelPackageValues)
            .HasForeignKey(f => f.PackageId);
            builder.HasOne(o => o.DailyCheckPackagesValues)
            .WithMany(w => w.RelPackageValues)
            .HasForeignKey(f => f.PackageValueId);
        }
    }
}
