using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.Property(q => q.Name).IsRequired();

            builder.HasData(
                new Exercise
                {
                    Id = 1,
                    Name = "Leg Press",
                    Description = "This is the description for Leg Press"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Deadlift",
                    Description = "This is the description for Deadlift"
                }
            );
        }
    }
}
