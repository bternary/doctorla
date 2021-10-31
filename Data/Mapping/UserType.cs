using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserTypeMapping : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserType","dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.DefaultName).IsRequired();
            builder.HasData(
                new UserType() { Id = 1 ,DefaultName = "Doctor" , Name="Doktor" },
                new UserType() { Id = 2, DefaultName = "Nurse"  , Name= "Hemşire" },
                new UserType() { Id = 3, DefaultName = "Patient", Name= "Hasta" },
                new UserType() { Id = 4, DefaultName = "Admin", Name= "Admin" }
                );
        }
    }
}
