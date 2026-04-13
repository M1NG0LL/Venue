using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venue.Domain.Entities;

namespace Venue.Infrastructure.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.VenueId)
                .IsRequired();

            builder.Property(x => x.Rate)
                .IsRequired();

            builder.Property(x => x.Comment)
                .IsRequired(false);

            builder.HasOne(x => x.Venue)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.VenueId, x.CreatedById })
                .IsUnique();
        }
    }
}
