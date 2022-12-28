using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class PostTagDto : IToEntityMapper<PostTag>
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public PostTagDto() { }
        public PostTagDto(PostTag entity)
        {
            Id = entity.Id;
            PostId = entity.PostId;
            TagId = entity.TagId;
            Tag = entity.Tag;
        }
        public PostTag MapToEntity()
        {
            return new PostTag
            {
                Id = Id,
                PostId = PostId,
                TagId = TagId,
                Tag = Tag
            };
        }
    }
}
