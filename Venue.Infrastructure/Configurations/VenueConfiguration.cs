using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using Venue.Domain.Entities;

namespace Venue.Infrastructure.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<VenueEntity>
    {
        public void Configure(EntityTypeBuilder<VenueEntity> builder)
        {
            builder.ToTable("Venues");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.ImagePath)
                .IsRequired(false);

            builder.OwnsOne(v => v.ContactInfo, info =>
            {
                info.Property(i => i.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                info.Property(i => i.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                info.Property(i => i.Address)
                    .IsRequired(false)
                    .HasMaxLength(300);

                info.Property(b => b.Location)
                    .HasColumnType("geometry");
            });

            builder.OwnsOne(v => v.Info, info =>
            {
                info.Property(i => i.SeatingCapacity)
                    .IsRequired();

                info.Property(i => i.PricePerEvent)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                info.Property(i => i.AvailableDays)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                              .Select(x => Enum.Parse<DayOfWeek>(x))
                              .ToList()
                    );
            });
        }
    }
}
