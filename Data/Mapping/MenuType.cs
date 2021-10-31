using System;
using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    class MenuTypeMapping : IEntityTypeConfiguration<MenuType>
    {
        public void Configure(EntityTypeBuilder<MenuType> builder)
        {
            builder.ToTable("MenuType", "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
