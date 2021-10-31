using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class SickMapping : IEntityTypeConfiguration<Sick>
    {
        public void Configure(EntityTypeBuilder<Sick> builder)
        {
            builder.ToTable(nameof(Sick), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
        }
    }
}
