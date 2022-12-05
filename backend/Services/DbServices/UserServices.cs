using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Models.Entities;
using Models.Extentions;
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

        public async Task<User> Create(User model)
        {
            await _dbContext.Users.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<User>> Create(List<User> models)
        {
            await _dbContext.Users.AddRangeAsync(models);
            await _dbContext.SaveChangesAsync();

            var addedUsers = await _dbContext.Users.AsNoTracking().ToListAsync();

            return addedUsers;
        }

        public async Task<User> Delete(int id)
        {
            var user = await Get(id);
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Get(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);

            if (user is null)
            {
                throw new UserNotFoundException();  //add text??
            }

            return user;
        }

        public async Task<List<User>> GetList()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Update(User newModel)
        {
            var user = await Get(newModel.Id);

            user.Update(newModel);

            await _dbContext.SaveChangesAsync();

            return newModel;
        }
    }
}
