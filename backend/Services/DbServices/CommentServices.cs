using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
using Services.Interfaces;
using Services.Exceptions;
using Models.Entities;
using Microsoft.IdentityModel.Tokens;

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

            return new CommentDto();    // think about return type
        }
        public async Task CreateRepliedComment(CommentDto model)
        {
            var parent = await _dbContext.Comments
                .Where(comment => comment.Id == model.Id)
                .Include(comment => comment.Replies)
                .SingleOrDefaultAsync();

            if (parent is null)
            {
                throw new CommentNotFoundException();  //add text??
            }
            var entity = new CommentDto()
            {
                PostId = model.PostId,
                Content = model.Content,
                UserId = model.UserId,
                CreationDate = model.CreationDate,
            }.MapToEntity();

            parent.Replies.Add(entity);

            await _dbContext.SaveChangesAsync();
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

            _dbContext.Comments.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new CommentDto(entity);
        }

        public async Task<CommentDto> Get(int id)
        {
            var comment = await _dbContext.Comments
                .Where(comment => comment.Id == id)
                .SingleOrDefaultAsync();

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
            var allComments = await _dbContext.Comments
                .Include(x => x.Replies)
                .Include(x => x.User)
                .Where(comment => comment.PostId == postId).ToListAsync();
            var allCommentsIds = allComments.Select(c => c.Id).ToList();

            var replies = await _dbContext.RepliedComments
                .Where(r => allCommentsIds.Contains(r.CommentId))
                .ToListAsync();

            foreach (var reply in replies)
            {
               var c = allComments.SingleOrDefault(x => x.Id == reply.RepliedCommentId);

                if (c != null)
                {
                    allComments.Remove(c);
                }
            }

            return allComments.Select(comment => new CommentDto(comment)
            {
                User = new UserDto(comment.User),
            }).ToList();
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
