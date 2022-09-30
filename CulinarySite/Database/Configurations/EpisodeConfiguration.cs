using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{    
    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasOne(x => x.CulinaryChannel)
                .WithMany(x => x.Episodes)
                .HasForeignKey(x => x.CulinaryChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Episodes)
                .UsingEntity(j => j.ToTable("EpisodeTag"));
        }
    }
}
