using CulinarySite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CulinarySite.Dal.EntityConfigurations
{
    public class CookingStageConfig : IEntityTypeConfiguration<CookingStage>
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
