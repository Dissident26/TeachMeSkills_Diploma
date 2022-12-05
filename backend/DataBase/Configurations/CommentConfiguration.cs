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
            builder.Property(comment => comment.Content).IsRequired();
            builder.Property(comment => comment.CreationDate).IsRequired();
            builder.HasOne(comment => comment.User)
                .WithMany(comment => comment.Comments)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(comment => comment.RepliedComment)
               .WithMany(comment => comment.Comments)
               .HasForeignKey(comment => comment.RepliedCommentId)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
