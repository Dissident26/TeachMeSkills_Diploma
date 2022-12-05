using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Models.Entities;
using Services.Interfaces;
using Services.Exceptions;

namespace Services.DbServices
{
    public class PostTagServices : IPostTagServices
    {
        private readonly DbContextMain _dbContext;
        public PostTagServices(DbContextMain context)
        {
            _dbContext = context;
        }

        public async Task<PostTag> Create(PostTag model)
        {
            await _dbContext.PostTags.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<PostTag>> Create(List<PostTag> models)
        {
            await _dbContext.PostTags.AddRangeAsync(models);
            await _dbContext.SaveChangesAsync();

            var addedTags = await _dbContext.PostTags.AsNoTracking().ToListAsync();

            return addedTags;
        }

        public async Task<PostTag> Delete(int id)
        {
            var tag = await Get(id);
            _dbContext.PostTags.Remove(tag);

            await _dbContext.SaveChangesAsync();

            return tag;
        }

        public async Task<PostTag> Get(int id)
        {
            var postTag = await _dbContext.PostTags.SingleOrDefaultAsync(postTag => postTag.Id == id);

            if (postTag is null)
            {
                throw new PostTagNotFoundException();  //add text??
            }

            return postTag;
        }

        public async Task<List<PostTag>> GetList()
        {
            return await _dbContext.PostTags.ToListAsync();
        }

        public async Task<PostTag> Update(PostTag newModel)
        {
            var postTag = await Get(newModel.Id);

            postTag.PostId = newModel.PostId;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
