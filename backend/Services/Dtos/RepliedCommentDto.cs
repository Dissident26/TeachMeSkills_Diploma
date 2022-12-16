using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class RepliedCommentDto : IToEntityMapper<RepliedComment>
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int RepliedCommentId { get; set; }
        public RepliedCommentDto() { }
        public RepliedCommentDto(RepliedComment entity)
        {
            Id = entity.Id;
            CommentId = entity.CommentId;
            RepliedCommentId = entity.RepliedCommentId;
        }
        public RepliedComment MapToEntity()
        {
            return new RepliedComment
            {
                Id = Id,
                CommentId = CommentId,
                RepliedCommentId = RepliedCommentId
            };
        }
    }
}
