using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models.Entities;

namespace DataBase.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(post => post.Id);
            builder.Property(post => post.Content).IsRequired();
            builder.HasOne(post => post.User)
                .WithMany(user => user.Posts)
                .HasForeignKey(post => post.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(post => post.Comments)
                .WithOne(comment => comment.Post)
                .HasForeignKey(comment => comment.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(post => post.Tags)
                .WithMany(tag => tag.Posts)
                .UsingEntity<PostTag>(
                   postTag => postTag.HasOne(postTag => postTag.Tag)
                        .WithMany(post => post.PostTags)
                        .HasForeignKey(userBook => userBook.TagId),
                    postTag => postTag.HasOne(postTag => postTag.Post)
                        .WithMany(post => post.PostTags)
                        .HasForeignKey(userBook => userBook.PostId)
                );
            builder.Property(post => post.CreationDate).IsRequired();
        }
    }
}

