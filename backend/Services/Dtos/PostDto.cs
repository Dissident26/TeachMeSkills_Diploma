using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class PostDto : IToEntityMapper<Post>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<PostTagDto> PostTags { get; set; }
        public UserDto User { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int CommentsCount { get; set; }
        public PostDto() { }
        public PostDto(Post entity)
        {
            Id = entity.Id;
            UserId = entity.UserId;
            Content = entity.Content;
            CreationDate = entity.CreationDate;
            Tags = entity.Tags?.Select(tag => new TagDto(tag)).ToList();
            PostTags = entity.PostTags?.Select(tag => new PostTagDto(tag)).ToList();
        }
        public Post MapToEntity()
        {
            return new Post
            {
                Id = Id,
                UserId = UserId,
                Content = Content,
                CreationDate = CreationDate,
                Tags = Tags?.Select(tag => tag.MapToEntity()).ToList(),
                PostTags = PostTags?.Select(tag => tag.MapToEntity()).ToList()
            };
        }
    }
}
