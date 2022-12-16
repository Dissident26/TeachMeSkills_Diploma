using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models.Entities;

namespace DataBase.Configurations
{
    internal class RepliedCommentConfiguration : IEntityTypeConfiguration<RepliedComment>
    {
        public void Configure(EntityTypeBuilder<RepliedComment> builder)
        {
            builder.HasKey(repliedComment => repliedComment.Id);
            builder.HasIndex(repliedComment => new { repliedComment.CommentId, repliedComment.RepliedCommentId }).IsUnique();
        }
    }
}
