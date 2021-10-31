using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class RelPackageDetailMapping : IEntityTypeConfiguration<RelPackageDetail>
    {
        public void Configure(EntityTypeBuilder<RelPackageDetail> builder)
        {
            builder.ToTable(nameof(RelPackageDetail), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IUser).HasDefaultValue(0);       
            builder.HasOne(o => o.Package)
            .WithMany(w => w.RelPackageDetail)
            .HasForeignKey(f => f.PackageId);
            builder.HasOne(o => o.PackageDetail)
            .WithMany(w => w.RelPackageDetail)
            .HasForeignKey(f => f.PackageDetailId);      
        }
    }
}
