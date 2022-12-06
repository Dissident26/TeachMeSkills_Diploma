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
            await _dbContext.Users.AddAsync(model.MapToEntity());
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<UserDto>> Create(List<UserDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Users.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            var addedUsers = await _dbContext.Users.AsNoTracking()
                .Select(user => new UserDto(user))
                .ToListAsync();

            return addedUsers;
        }

        public async Task<UserDto> Delete(int id)
        {
            var user = await Get(id);
            _dbContext.Users.Remove(user.MapToEntity());

            await _dbContext.SaveChangesAsync();

            return user;
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
            var user = await Get(newModel.Id);

            user.Name = newModel.Name;
            user.Email = newModel.Email;

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
