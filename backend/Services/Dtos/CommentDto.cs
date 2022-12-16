using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class CommentDto : IToEntityMapper<Comment>
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public UserDto User { get; set; }
        public int? RepliedCommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CommentDto> RepliedComments { get; set; }
        public CommentDto() { }
        public CommentDto(Comment entity)
        {
            Id = entity.Id;
            PostId = entity.PostId;
            UserId = entity.UserId;
            Content = entity.Content;
            CreationDate = entity.CreationDate;
        }
        public Comment MapToEntity()
        {
            return new Comment
            {
                Id = Id,
                PostId = PostId,
                UserId = UserId,
                Content = Content,
                CreationDate = CreationDate
            };
        }
    }
}
