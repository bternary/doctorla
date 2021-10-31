using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class DailyCheckPackagesMapping : IEntityTypeConfiguration<DailyCheckPackages>
    {
        public void Configure(EntityTypeBuilder<DailyCheckPackages> builder)
        {
            builder.ToTable(nameof(DailyCheckPackages), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

       
        }
    }
}
