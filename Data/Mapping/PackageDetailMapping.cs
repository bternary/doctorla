using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class PackageDetailMapping : IEntityTypeConfiguration<PackageDetail>
    {
        public void Configure(EntityTypeBuilder<PackageDetail> builder)
        {
            builder.ToTable(nameof(PackageDetail), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
        }
    }
}
