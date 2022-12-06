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
            await _dbContext.Tags.AddAsync(model.MapToEntity());
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<TagDto>> Create(List<TagDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Tags.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            var addedTags = await _dbContext.Tags.AsNoTracking()
                .Select(tag => new TagDto(tag))
                .ToListAsync();

            return addedTags;
        }

        public async Task<TagDto> Delete(int id)
        {
            var tag = await Get(id);
            _dbContext.Tags.Remove(tag.MapToEntity());

            await _dbContext.SaveChangesAsync();

            return tag;
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
            var tag = await Get(newModel.Id);

            tag.Name = newModel.Name;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
