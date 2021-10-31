using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class AddressMapping : IEntityTypeConfiguration<Address>
  {
    public void Configure(EntityTypeBuilder<Address> builder)
    {
      builder.ToTable(nameof(Address), "dbo");
      builder.HasKey(o => o.Id);
      builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
      builder.HasOne(m => m.AddressType)
      .WithMany(w => w.Address)
      .HasForeignKey(f => f.TypeId);
      
      builder.HasOne(m => m.User)
      .WithMany(w => w.Address)
      .HasForeignKey(f => f.UserId)
      .OnDelete(DeleteBehavior.Restrict);  
    }
  }
}
