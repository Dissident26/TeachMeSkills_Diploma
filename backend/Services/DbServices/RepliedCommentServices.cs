using DataBase.Contexts;
using Services.Dtos;
using Services.Interfaces;
using Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Services.DbServices
{
    public class RepliedCommentServices : IRepliedCommentServices
    {
        private readonly DbContextMain _dbContext;
        public RepliedCommentServices(DbContextMain context)
        {
            _dbContext = context;
        }
        public async Task<RepliedCommentDto> Create(RepliedCommentDto model)
        {
            var entity = model.MapToEntity();
            await _dbContext.RepliedComments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new RepliedCommentDto(entity);
        }

        public async Task<List<RepliedCommentDto>> Create(List<RepliedCommentDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.RepliedComments.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.RepliedComments.AsNoTracking()
                .Select(repliedComment => new RepliedCommentDto(repliedComment)).ToListAsync();
        }

        public Task<RepliedComment> Create(RepliedComment model)
        {
            throw new NotImplementedException();
        }
        public async Task<RepliedCommentDto> Delete(int id)
        {
            var entity = await _dbContext.RepliedComments.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new CommentNotFoundException();  //add text??
            }

            _dbContext.RepliedComments.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new RepliedCommentDto(entity);
        }
        public async Task<RepliedCommentDto> Get(int id)
        {
            var repliedComment = await _dbContext.RepliedComments
                .SingleOrDefaultAsync(repliedComment => repliedComment.Id == id);

            if (repliedComment is null)
            {
                throw new CommentNotFoundException();  //add text??
            }

            return new RepliedCommentDto(repliedComment);
        }

        public async Task<List<RepliedCommentDto>> Get(int[] ids)
        {
            return await _dbContext.RepliedComments.Where(repliedComment => ids.Contains(repliedComment.Id))
                .Select(repliedComment => new RepliedCommentDto(repliedComment))
                .ToListAsync();
        }

        public async Task<List<RepliedCommentDto>> GetList()
        {
            return await _dbContext.RepliedComments.Select(repliedComment => new RepliedCommentDto(repliedComment)).ToListAsync();
        }

        public async Task<RepliedCommentDto> Update(RepliedCommentDto newModel)
        {
            var entity = await _dbContext.RepliedComments.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new CommentNotFoundException();  //add text??
            }

            entity.RepliedCommentId = newModel.RepliedCommentId;
            entity.CommentId = newModel.CommentId;

            await _dbContext.SaveChangesAsync();

            return new RepliedCommentDto(entity);
        }
        public async Task<List<CommentDto>> GetListByComment(int commentId)
        {
            var repliedComments = await _dbContext.RepliedComments
                .AsNoTracking()
                .Where(repliedComment => repliedComment.CommentId == commentId)
                .Select(repliedComment => repliedComment.RepliedCommentId)
                .ToListAsync();

            return await _dbContext.Comments.Where(comment => repliedComments.Contains(comment.Id))
                .Select(comment => new CommentDto(comment))
                .ToListAsync();
        }
    }
}
