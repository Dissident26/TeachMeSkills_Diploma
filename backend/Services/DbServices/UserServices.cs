using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
using Services.Interfaces;
using Services.Exceptions;

namespace Services.DbServices
{
    public class UserServices : IUserServices
    {
        private readonly DbContextMain _dbContext;
        public UserServices(DbContextMain context)
        {
            _dbContext = context;
        }

        public async Task<UserDto> Create(UserDto model)
        {
            var entity = model.MapToEntity();
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            
            return new UserDto(entity);
        }
        public async Task<List<UserDto>> Create(List<UserDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Users.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Users.AsNoTracking().Select(user => new UserDto(user)).ToListAsync();
        }
        public async Task<UserDto> Delete(int id)
        {
            var entity = await _dbContext.Users.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new UserNotFoundException();  //add text??
            }

            await _dbContext.Comments
                .Where(comment => comment.UserId == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(comment => comment.UserId, comment => null));

            await _dbContext.Posts
                .Where(post => post.UserId == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(post => post.UserId, post => null));

            _dbContext.Users.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new UserDto(entity);
        }
        public async Task<UserDto> Get(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);

            if (user is null)
            {
                throw new UserNotFoundException();  //add text??
            }

            return new UserDto(user);
        }
        public async Task<List<UserDto>> GetList()
        {
            return await _dbContext.Users.Select(user => new UserDto(user)).ToListAsync();
        }
        public async Task<UserDto> Update(UserDto newModel)
        {
            var entity = await _dbContext.Users.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new UserNotFoundException();  //add text??
            }

            entity.Name = newModel.Name;
            entity.Avatar = newModel.Avatar;

            await _dbContext.SaveChangesAsync();

            return new UserDto(entity);
        }
    }
}
