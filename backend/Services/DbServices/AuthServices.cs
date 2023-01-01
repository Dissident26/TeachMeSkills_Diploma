using DataBase.Contexts;
using Microsoft.EntityFrameworkCore;

using Services.Dtos;
using Services.Exceptions;
using Services.Interfaces;

namespace Services.DbServices
{
    internal class AuthServices : IAuthServices
    {
        private readonly DbContextMain _dbContext;
        public AuthServices(DbContextMain context)
        {
            _dbContext = context;
        }
        public async Task Create(UserAuthModelDto model)
        {
            await _dbContext.AuthorisedUsers.AddAsync(model.MapToEntity());
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(UserAuthModelDto newModel)
        {
            var entity = await _dbContext.AuthorisedUsers.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new UserNotFoundException();
            }

            entity.Name = newModel.Name;
            entity.Password = newModel.Password;

            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _dbContext.AuthorisedUsers.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new UserNotFoundException();
            }

            _dbContext.AuthorisedUsers.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
        public async Task<UserDto> ValidateUser(UserAuthModelDto userAuthModel)
        {
            var entity = await _dbContext.AuthorisedUsers
                .AsNoTracking() //add encryption
                .SingleOrDefaultAsync(entity => entity.Name == userAuthModel.Name && entity.Password == userAuthModel.Password);

            if(entity is null)
            {
                throw new InvalidCredentialsException();
            }

            var user = await _dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Id == entity.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            return new UserDto(user);
        }
    }
}
