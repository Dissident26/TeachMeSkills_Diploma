using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
using Services.Interfaces;
using Services.Exceptions;

namespace Services.DbServices
{
    public class CommentServices : ICommentServices
    {
        private readonly DbContextMain _dbContext;
        public CommentServices(DbContextMain context)
        {
            _dbContext = context;
        }

        public async Task<CommentDto> Create(CommentDto model)
        {
            var entity = model.MapToEntity();
            await _dbContext.Comments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new CommentDto(entity);
        }

        public async Task<List<CommentDto>> Create(List<CommentDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Comments.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Comments.AsNoTracking().Select(comment => new CommentDto(comment)).ToListAsync();
        }

        public async Task<CommentDto> Delete(int id)
        {
            var entity = await _dbContext.Comments
                .SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new CommentNotFoundException();  //add text??
            }

            //await _dbContext.Comments
            //    .Where(comment => comment.RepliedCommentId == id)
            //    .ExecuteUpdateAsync(s =>
            //        s.SetProperty(comment => comment.RepliedCommentId, comment => null));

            _dbContext.Comments.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new CommentDto(entity);
        }

        public async Task<CommentDto> Get(int id)
        {
            var comment = await _dbContext.Comments.SingleOrDefaultAsync(comment => comment.Id == id);

            if (comment is null)
            {
                throw new CommentNotFoundException();  //add text??
            }

            return new CommentDto(comment);
        }

        public async Task<List<CommentDto>> Get(int[] ids)
        {
            return await _dbContext.Comments.Where(comment => ids.Contains(comment.Id))
                .Select(comment => new CommentDto(comment))
                .ToListAsync();
        }

        public async Task<List<CommentDto>> GetList()
        {
            return await _dbContext.Comments
                .Select(comment => new CommentDto(comment)).ToListAsync();
        }

        public async Task<List<CommentDto>> GetListByPost(int postId)
        {
            return await _dbContext.Comments
                .Where(comment => comment.PostId == postId)
                .Select(comment => new CommentDto(comment)
                {
                    User = new UserDto(comment.User),
                }).ToListAsync();
        }

        public async Task<CommentDto> Update(CommentDto newModel)
        {
            var entity = await _dbContext.Comments.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new CommentNotFoundException();  //add text??
            }

            entity.Content = newModel.Content;

            await _dbContext.SaveChangesAsync();

            return new CommentDto(entity);
        }
    }
}
