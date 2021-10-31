using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class PaymentProcessMapping : IEntityTypeConfiguration<PaymentProcess>
    {
        public void Configure(EntityTypeBuilder<PaymentProcess> builder)
        {
            builder.ToTable(nameof(PaymentProcess), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);

        }
    }
}
