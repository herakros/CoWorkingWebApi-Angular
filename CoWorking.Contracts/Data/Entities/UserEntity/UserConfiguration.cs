using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoWorking.Contracts.Data.Entities.UserEntity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
