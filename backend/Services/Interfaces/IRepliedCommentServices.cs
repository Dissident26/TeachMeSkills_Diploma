using Models.Entities;
using Services.Dtos;

namespace Services.Interfaces
{
    public interface IRepliedCommentServices : ICRUDAsync<RepliedCommentDto>
    {
        public Task<List<CommentDto>> GetListByComment(int commentId);
    }
}
