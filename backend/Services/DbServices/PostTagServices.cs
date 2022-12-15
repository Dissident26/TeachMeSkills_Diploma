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
            var entity = model.MapToEntity();
            await _dbContext.PostTags.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new PostTagDto(entity);
        }

        public async Task<List<PostTagDto>> Create(List<PostTagDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.PostTags.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.PostTags.AsNoTracking().Select(postTag => new PostTagDto(postTag)).ToListAsync();
        }

        public async Task<PostTagDto> Delete(int id)
        {
            var entity = await _dbContext.PostTags.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new PostTagNotFoundException();  //add text??
            }

            _dbContext.PostTags.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new PostTagDto(entity);
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

        public async Task<List<PostTagDto>> Get(int[] ids)
        {
            return await _dbContext.PostTags.Where(postTag => ids.Contains(postTag.Id))
                .Select(postTag => new PostTagDto(postTag))
                .ToListAsync();
        }

        public async Task<List<PostTagDto>> GetList()
        {
            return await _dbContext.PostTags.Select(postTag => new PostTagDto(postTag)).ToListAsync();
        }

        public async Task<PostTagDto> Update(PostTagDto newModel)
        {
            var entity = await _dbContext.PostTags.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new PostTagNotFoundException();  //add text??
            }

            entity.PostId = newModel.PostId;

            await _dbContext.SaveChangesAsync();

            return new PostTagDto(entity);
        }
    }
}
