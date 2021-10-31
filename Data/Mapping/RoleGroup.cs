using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class RoleGroupMapping : IEntityTypeConfiguration<RoleGroup>
    {
        public void Configure(EntityTypeBuilder<RoleGroup> builder)
        {
            builder.ToTable("RoleGroup", "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.DefaultName).IsRequired();
            builder.HasData(
                new RoleGroup() { Id = 1 ,DefaultName = "Admin", Name= "Admin" },
                new RoleGroup() { Id = 3, DefaultName = "User", Name= "User" }
                );
        }
    }
}
