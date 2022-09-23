using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{
    
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasOne(x => x.Address)
                .WithMany(x => x.Restaurants)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
