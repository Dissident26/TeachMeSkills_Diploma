using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Models.Entities;
using Services.Interfaces;
using Services.Exceptions;

namespace Services.DbServices
{
    public class PostServices : IPostServices
    {
        private readonly DbContextMain _dbContext;
        public PostServices(DbContextMain context)
        {
            _dbContext = context;
        }

        public async Task<Post> Create(Post model)
        {
            await _dbContext.Posts.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<Post>> Create(List<Post> models)
        {
            await _dbContext.Posts.AddRangeAsync(models);
            await _dbContext.SaveChangesAsync();

            var addedPosts = await _dbContext.Posts.AsNoTracking().ToListAsync();

            return addedPosts;
        }

        public async Task<Post> Delete(int id)
        {
            var tag = await Get(id);
            _dbContext.Posts.Remove(tag);

            await _dbContext.SaveChangesAsync();

            return tag;
        }

        public async Task<Post> Get(int id)
        {
            var post = await _dbContext.Posts.SingleOrDefaultAsync(post => post.Id == id);

            if (post is null)
            {
                throw new PostNotFoundException();  //add text??
            }

            return post;
        }

        public async Task<List<Post>> GetList()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> Update(Post newModel)
        {
            var post = await Get(newModel.Id);

            post.Content = newModel.Content;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
