using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            
            builder.HasOne(x => x.Dish)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.DishId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Episode)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.EpisodeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CookingStage)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.CookingStageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Recipe)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.RecipeId)
                .OnDelete(DeleteBehavior.NoAction);

            /*builder.HasOne(x => x.Dish)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Episode)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.CookingStage)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.CookingStageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Recipe)
                .WithOne(x => x.Image)
                .HasForeignKey<Image>(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }

}

