using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_9_2.Entities;

namespace Task_9_2.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");

            entity.HasIndex(x => x.Email).IsUnique();

            entity.Property(x => x.Email).IsRequired().HasMaxLength(128);
            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(128);
            entity.Property(x => x.LastName).IsRequired().HasMaxLength(128);

            entity.HasMany(x => x.Vacations).WithOne().HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Trainings)
                .WithMany(x => x.Employees)
                .UsingEntity<EmployeeTraining>(
                    t => t.HasOne<Training>().WithMany().HasForeignKey(x => x.TrainingId),
                    e => e.HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeId),
                    x => x.ToTable("EmployeeTraining"));
        }
    }
}