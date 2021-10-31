using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class DoctorDetailMapping : IEntityTypeConfiguration<DoctorDetail>
    {
        public void Configure(EntityTypeBuilder<DoctorDetail> builder)
        {
            builder.ToTable("DoctorDetail", "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.HasOne(m => m.User)
             .WithOne(f => f.DoctorDetail)
             .HasForeignKey<DoctorDetail>(x => x.UserId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
