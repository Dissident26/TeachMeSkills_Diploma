using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
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

        public async Task<PostDto> Create(PostDto model)
        {
            await _dbContext.Posts.AddAsync(model.MapToEntity());
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<PostDto>> Create(List<PostDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Posts.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            var addedPosts = await _dbContext.Posts.AsNoTracking()
                .Select(post => new PostDto(post))
                .ToListAsync();

            return addedPosts;
        }

        public async Task<PostDto> Delete(int id)
        {
            var post = await Get(id);
            _dbContext.Posts.Remove(post.MapToEntity());

            await _dbContext.SaveChangesAsync();

            return post;
        }

        public async Task<PostDto> Get(int id)
        {
            var post = await _dbContext.Posts.SingleOrDefaultAsync(post => post.Id == id);

            if (post is null)
            {
                throw new PostNotFoundException();  //add text??
            }

            return new PostDto(post);
        }

        public async Task<List<PostDto>> GetList()
        {
            return await _dbContext.Posts
                .Select(post => new PostDto(post)).ToListAsync();
        }

        public async Task<PostDto> Update(PostDto newModel)
        {
            var post = await Get(newModel.Id);

            post.Content = newModel.Content;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
