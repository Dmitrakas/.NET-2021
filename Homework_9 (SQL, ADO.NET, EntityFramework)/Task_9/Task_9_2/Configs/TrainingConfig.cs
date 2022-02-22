using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_9_2.Entities;

namespace Task_9_2.Configs
{
    public class TrainingConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> entity)
        {
            entity.ToTable("Training");

            entity.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entity.Property(x => x.StartDate).HasColumnType("date");
            entity.Property(x => x.EndDate).HasColumnType("date");
        }
    }
}