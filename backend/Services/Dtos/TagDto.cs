using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class TagDto : IToEntityMapper<Tag>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagDto() { }
        public TagDto(Tag entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
        public Tag MapToEntity()
        {
            return new Tag
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
