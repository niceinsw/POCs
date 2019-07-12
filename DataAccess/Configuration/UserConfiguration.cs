using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                    .HasMaxLength(50);

            builder.Property(u => u.UserName)
                    .HasMaxLength(50);

            builder.Property(u => u.DateCreated);
        }
    }
}
