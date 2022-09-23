using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{

    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            /* builder.HasOne(x => x.Book)
                 .WithMany(x => x.Recipes)
                 .HasForeignKey(x => x.BookId)
                 .OnDelete(DeleteBehavior.SetNull);*/

            builder.HasOne(x => x.Dish)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Ingredients)
                .WithMany(x => x.Recipes)
                .UsingEntity(j => j.ToTable("IngredientRecipe"));

            builder.HasMany(x => x.OrganicMatters)
                .WithMany(x => x.Recipes)
                .UsingEntity(j => j.ToTable("OrganicMatterRecipe"));

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Recipes)
                .UsingEntity(j => j.ToTable("RecipeTag"));
        }
    }
}
