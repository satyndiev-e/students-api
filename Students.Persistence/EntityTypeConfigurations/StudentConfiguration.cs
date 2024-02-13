using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain;

namespace Students.Persistence.EntityTypeConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);
            builder.HasIndex(student => student.Id).IsUnique();
            builder.Property(student => student.FirstName).HasMaxLength(50);
            builder.Property(student => student.LastName).HasMaxLength(50);
            builder.Property(student => student.DateOfBirth).IsRequired();

            builder.HasOne(student => student.Gender)
                .WithMany(gender => gender.Students)
                .HasForeignKey(student => student.GenderId)
                .IsRequired();
        }
    }
}
