using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Models.Entities;
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

        public async Task<Tag> Create(Tag model)
        {
            await _dbContext.Tags.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<Tag>> Create(List<Tag> models)
        {
            await _dbContext.Tags.AddRangeAsync(models);
            await _dbContext.SaveChangesAsync();

            var addedTags = await _dbContext.Tags.AsNoTracking().ToListAsync();

            return addedTags;
        }

        public async Task<Tag> Delete(int id)
        {
            var tag = await Get(id);
            _dbContext.Tags.Remove(tag);

            await _dbContext.SaveChangesAsync();

            return tag;
        }

        public async Task<Tag> Get(int id)
        {
            var tag = await _dbContext.Tags.SingleOrDefaultAsync(tag => tag.Id == id);

            if (tag is null)
            {
                throw new TagNotFoundException();  //add text??
            }

            return tag;
        }

        public async Task<List<Tag>> GetList()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag> Update(Tag newModel)
        {
            var tag = await Get(newModel.Id);

            tag.Name = newModel.Name;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
