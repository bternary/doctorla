using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class ReferanceMapping : IEntityTypeConfiguration<Referance>
    {
        public void Configure(EntityTypeBuilder<Referance> builder)
        {
            builder.ToTable("Referance", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(b => b.Key).IsRequired();
            builder.Property(b => b.Value).IsRequired();
        }
    }
}
