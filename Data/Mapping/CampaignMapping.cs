using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class CampaignMapping : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable(nameof(Campaign), "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CampaignType).HasConversion<int>();
        }
    }
}