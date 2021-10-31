using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class PackageOffersMapping : IEntityTypeConfiguration<PackageOffers>
    {
        public void Configure(EntityTypeBuilder<PackageOffers> builder)
        {
            builder.ToTable(nameof(PackageOffers), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.HasOne(m => m.Package)
                .WithMany(m => m.Offers)
                .HasForeignKey(m => m.PackageId);
        }
    }
}
