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
            await _dbContext.Comments.AddAsync(model.MapToEntity());
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<CommentDto>> Create(List<CommentDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Comments.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            var addedComments = await _dbContext.Comments.AsNoTracking()
                .Select(comment => new CommentDto(comment))
                .ToListAsync();

            return addedComments;
        }

        public async Task<CommentDto> Delete(int id)
        {
            var comment = await Get(id);
            _dbContext.Comments.Remove(comment.MapToEntity());

            await _dbContext.SaveChangesAsync();

            return comment;
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

        public async Task<List<CommentDto>> GetList()
        {
            return await _dbContext.Comments
                .Select(comment => new CommentDto(comment)).ToListAsync();
        }

        public async Task<CommentDto> Update(CommentDto newModel)
        {
            var post = await Get(newModel.Id);

            post.Content = newModel.Content;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
