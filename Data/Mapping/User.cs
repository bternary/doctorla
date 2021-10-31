using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");
            builder.HasKey(o => o.Id);     
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.PhotoUrl).HasDefaultValue("/images/Users/defaultuser.png");
           builder.HasOne(m => m.UserType)
                .WithMany(w => w.Users)
                .HasForeignKey(f => f.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.HasOne(m=> m.RoleGroup)
            .WithMany(w => w.Users)
            .HasForeignKey(f => f.RoleGroupId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.DoctorDetail)
                .WithOne(f => f.User)
                .HasForeignKey<DoctorDetail>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.UserDetail)
            .WithOne(f => f.User)
            .HasForeignKey<UserDetail>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
