using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models.Entities;

namespace DataBase.Configurations
{
    internal class UserAuthModelConfiguration : IEntityTypeConfiguration<UserAuthModel>
    {
        public void Configure(EntityTypeBuilder<UserAuthModel> builder)
        {
            builder.HasKey(userAuthModel => userAuthModel.Id);
            builder.HasIndex(userAuthModel => userAuthModel.Email).IsUnique();
            builder.HasOne(userAuthModel => userAuthModel.User)
                .WithOne(user => user.UserAuthModel)
                .HasForeignKey<UserAuthModel>(userAuthModel => userAuthModel.UserId);
        }
    }
}
