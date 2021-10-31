using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class RelUserDepartmentMapping : IEntityTypeConfiguration<RelUserDepartment>
    {
        public void Configure(EntityTypeBuilder<RelUserDepartment> builder)
        {
            builder.ToTable(nameof(RelUserDepartment), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IUser).HasDefaultValue(0);
            builder.Property(x => x.SessionTime).HasDefaultValue(10);
            builder.Property(x => x.Price).HasDefaultValue(10);
            builder.HasOne(o => o.User)
            .WithMany(w => w.RelUserDepartments)
            .HasForeignKey(f => f.UserId);
            builder.HasOne(o => o.Department)
            .WithMany(w => w.RelUserDepartments)
            .HasForeignKey(f => f.DepartmentId);      
        }
    }
}
