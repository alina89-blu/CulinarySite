using Database;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
             //Database.EnsureDeleted();
             Database.EnsureCreated();
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<CookingStage> CookingStages { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<OrganicMatter> OrganicMatters { get; set; }
        public DbSet<CulinaryChannel> CulinaryChannels { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(p => p.Author)
                .WithMany(t => t.Books)
                .OnDelete(DeleteBehavior.SetNull);
        }*/
    }
}
