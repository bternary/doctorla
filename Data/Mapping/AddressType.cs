using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
  public class AddressTypeMapping : IEntityTypeConfiguration<AddressType>
  {
    public void Configure(EntityTypeBuilder<AddressType> builder)
    {
      builder.ToTable(nameof(AddressType), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.HasData(
                new AddressType() {Id=1,DefaultName="Home Address",Name="Ev Adresi" },
                new AddressType() {Id=2,DefaultName="Work Address",Name="Ýþ Adresi" }
                );
      // builder.HasOne(m => m.Country)
      // .WithMany(w => w.Cities)
      // .HasForeignKey(f => f.CountryId)
      // .OnDelete(DeleteBehavior.Restrict)
      // .IsRequired();
    }
  }
}
