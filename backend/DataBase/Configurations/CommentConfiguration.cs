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
            builder.HasMany(comment => comment.Comments)
               .WithMany(comment => comment.Replies)
               .UsingEntity<RepliedComment>(
                    repliedComment => repliedComment
                        .HasOne(repliedComment => repliedComment.Comment)
                        .WithMany()
                        .HasForeignKey(repliedComment => repliedComment.CommentId),
                    repliedComment => repliedComment
                        .HasOne(repliedComment => repliedComment.Reply)
                        .WithMany()
                        .HasForeignKey(repliedComment => repliedComment.RepliedCommentId)
                );

        }
    }
}