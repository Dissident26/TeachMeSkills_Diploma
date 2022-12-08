using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
using Services.Interfaces;
using Services.Exceptions;

namespace Services.DbServices
{
    public class TagServices : ITagServices
    {
        private readonly DbContextMain _dbContext;
        public TagServices(DbContextMain context)
        {
            _dbContext = context;
        }

        public async Task<TagDto> Create(TagDto model)
        {
            var entity = model.MapToEntity();
            await _dbContext.Tags.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new TagDto(entity);
        }

        public async Task<List<TagDto>> Create(List<TagDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Tags.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            return mappedModels.Select(tag => new TagDto(tag)).ToList();
        }

        public async Task<TagDto> Delete(int id)
        {
            var entity = await _dbContext.Tags.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new TagNotFoundException();  //add text??
            }

            _dbContext.Tags.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new TagDto(entity);
        }

        public async Task<TagDto> Get(int id)
        {
            var tag = await _dbContext.Tags.SingleOrDefaultAsync(tag => tag.Id == id);

            if (tag is null)
            {
                throw new TagNotFoundException();  //add text??
            }

            return new TagDto(tag);
        }

        public async Task<List<TagDto>> GetList()
        {
            return await _dbContext.Tags
                .Select(tag => new TagDto(tag))
                .ToListAsync();
        }

        public async Task<TagDto> Update(TagDto newModel)
        {
            var entity = await _dbContext.Tags.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new TagNotFoundException();  //add text??
            }

            entity.Name = newModel.Name;

            await _dbContext.SaveChangesAsync();

            return new TagDto(entity);
        }
    }
}
