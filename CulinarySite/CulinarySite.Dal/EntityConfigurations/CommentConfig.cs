using CulinarySite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CulinarySite.Dal.EntityConfigurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {            
            builder.HasMany(x => x.Restaurants)
                .WithMany(x => x.Comments)
                .UsingEntity(j => j.ToTable("CommentRestaurant"));
        }
    }
}