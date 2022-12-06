using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class PostDto : IToEntityMapper<Post>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public PostDto() { }
        public PostDto(Post entity)
        {
            Id = entity.Id;
            UserId = entity.UserId;
            Content = entity.Content;
            CreationDate = entity.CreationDate;
        }
        public Post MapToEntity()
        {
            return new Post
            {
                Id = Id,
                UserId = UserId,
                Content = Content,
                CreationDate = CreationDate
            };
        }
    }
}
