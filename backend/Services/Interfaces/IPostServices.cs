using Services.Dtos;

namespace Services.Interfaces
{
    public interface IPostServices : ICRUDAsync<PostDto>
    {
        public Task<List<PostDto>> GetPostsByTagId(int id);
    }
}
