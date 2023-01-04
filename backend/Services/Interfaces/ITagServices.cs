using Services.Dtos;

namespace Services.Interfaces
{
    public interface ITagServices : ICRUDAsync<TagDto>
    {
        public Task<List<TagDto>> GetSuggestedTags(string input);
    }
}
