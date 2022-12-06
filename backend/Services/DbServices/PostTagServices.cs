using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
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

        public async Task<PostTagDto> Create(PostTagDto model)
        {
            await _dbContext.PostTags.AddAsync(model.MapToEntity());
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<PostTagDto>> Create(List<PostTagDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.PostTags.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            var addedTags = await _dbContext.PostTags.AsNoTracking()
                .Select(postTag => new PostTagDto(postTag))
                .ToListAsync();

            return addedTags;
        }

        public async Task<PostTagDto> Delete(int id)
        {
            var tag = await Get(id);
            _dbContext.PostTags.Remove(tag.MapToEntity());

            await _dbContext.SaveChangesAsync();

            return tag;
        }

        public async Task<PostTagDto> Get(int id)
        {
            var postTag = await _dbContext.PostTags.SingleOrDefaultAsync(postTag => postTag.Id == id);

            if (postTag is null)
            {
                throw new PostTagNotFoundException();  //add text??
            }

            return new PostTagDto(postTag);
        }

        public async Task<List<PostTagDto>> GetList()
        {
            return await _dbContext.PostTags.Select(postTag => new PostTagDto(postTag)).ToListAsync();
        }

        public async Task<PostTagDto> Update(PostTagDto newModel)
        {
            var postTag = await Get(newModel.Id);

            postTag.PostId = newModel.PostId;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
