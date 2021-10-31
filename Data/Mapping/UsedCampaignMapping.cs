using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class UsedCampaignMapping : IEntityTypeConfiguration<UsedCampaign>
    {
        public void Configure(EntityTypeBuilder<UsedCampaign> builder)
        {
            builder.ToTable(nameof(UsedCampaign), "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UsedDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IUser).HasDefaultValue(1);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.HasOne(m => m.Campaign)
            .WithMany(m => m.UsedCampaigns)
            .HasForeignKey(m => m.CampaignId);
            builder.HasOne(m => m.User)
            .WithMany(m => m.UsedCampaigns)
            .HasForeignKey(m => m.UserId);
        }
    }
}