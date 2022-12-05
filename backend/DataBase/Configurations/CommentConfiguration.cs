using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models.Entities;

namespace DataBase.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.Id);
            builder.Property(comment => comment.PostId).IsRequired();
            builder.Property(comment => comment.RepliedCommentId);
            builder.Property(comment => comment.Content).IsRequired();
            builder.Property(comment => comment.CreationDate).IsRequired();
            builder.HasIndex(comment => new { comment.PostId, comment.Id });
            builder.HasIndex(comment => new { comment.UserId, comment.Id });
            builder.HasIndex(comment => new { comment.RepliedCommentId, comment.Id });
            builder.HasOne(comment => comment.User)
                .WithMany(comment => comment.Comments)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            // тут
            builder.HasOne(comment => comment.Post)
               .WithMany(comment => comment.Comments)
               .HasForeignKey(comment => comment.PostId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(comment => comment.RepliedComment)
               .WithMany(comment => comment.Comments)
               .HasForeignKey(comment => comment.RepliedCommentId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
