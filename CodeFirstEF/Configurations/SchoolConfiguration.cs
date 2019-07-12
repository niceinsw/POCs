using CodeFirstEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstEF.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("Schools");
            builder.Property(x => x.SchoolId).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.HasKey(x => x.SchoolId);
            builder.HasMany(b => b.Teachers).WithOne(p => p.School);
            builder.Property(x => x.SchoolName).HasMaxLength(200);
            builder.Property(x => x.PostCode).HasMaxLength(10);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.City).HasMaxLength(50);            
        }
    }
}
