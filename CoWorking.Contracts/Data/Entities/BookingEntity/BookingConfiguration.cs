using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoWorking.Contracts.Data.Entities.BookingEntity
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired();

            builder
                .Property(x => x.DateStart)
                .IsRequired();

            builder
                .Property(x => x.DateEnd)
                .IsRequired();

            builder
                .HasOne(x => x.Developer)
                .WithOne(x => x.Booking)
                .HasForeignKey<Booking>(x => x.DeveloperId);
        }
    }
}
