using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class NotifyTokensMapping : IEntityTypeConfiguration<NotifyTokens>
  {
    public void Configure(EntityTypeBuilder<NotifyTokens> builder)
    {
      builder.ToTable(nameof(NotifyTokens), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(o => o.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);

    }
  }
}
