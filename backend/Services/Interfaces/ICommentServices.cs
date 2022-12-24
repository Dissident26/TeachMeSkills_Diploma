using Services.Dtos;

namespace Services.Interfaces
{
    public interface ICommentServices : ICRUDAsync<CommentDto>
    {
        public Task<List<CommentDto>> GetListByPost(int postId);
        public Task CreateRepliedComment(CommentDto comment);
    }
}