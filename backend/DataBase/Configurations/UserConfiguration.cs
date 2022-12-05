using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models.Entities;

namespace DataBase.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Name).HasMaxLength(100).IsRequired();
            builder.Property(user => user.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(user => user.Name).IsUnique();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.HasIndex(user => user.RegistrationDate).IsUnique();
        }
    }
}
