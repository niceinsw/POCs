using ef.core.codefirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ef.core.codefirst.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId).ValueGeneratedOnAdd();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
        }
    }
}
