using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{
    public class TelephoneConfiguration : IEntityTypeConfiguration<Telephone>
    {
        public void Configure(EntityTypeBuilder<Telephone> builder)
        {
            builder.HasOne(x => x.Restaurant)
                .WithMany(x => x.Telephones)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}