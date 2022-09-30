using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{
    public class CookingStageConfiguration : IEntityTypeConfiguration<CookingStage>
    {
        public void Configure(EntityTypeBuilder<CookingStage> builder)
        {
            builder.HasOne(x => x.Recipe)
                .WithMany(x => x.CookingStages)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
