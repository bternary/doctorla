using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country), "dbo");
            builder.HasKey(o => o.Id);
                 builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
        }
    }
}
