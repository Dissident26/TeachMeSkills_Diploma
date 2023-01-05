using Services.Dtos;

namespace Services.Interfaces
{
    public interface IPostServices : ICRUDAsync<PostDto>
    {
        public Task<List<PostDto>> GetPostsByTagId(int id);
        public Task<PostPageDto> GetListPage(int pageNumber);
        public Task<PostPageDto> GetLatest();
    }
}
