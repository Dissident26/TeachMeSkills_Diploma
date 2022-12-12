﻿using DataBase.Contexts;
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
                throw new UserNotFoundException();  //add text??
            }

            entity.Email = newModel.Email;
            entity.Password = newModel.Password;

            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _dbContext.AuthorisedUsers.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new UserNotFoundException();  //add text??
            }

            _dbContext.AuthorisedUsers.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
        public async Task<UserDto> ValidateUser(string email, string password)
        {
            var entity = await _dbContext.AuthorisedUsers
                .AsNoTracking()
                .SingleOrDefaultAsync(entity => entity.Email == email && entity.Password == password);

            if(entity is null)
            {
                throw new InvalidCredentialsException(); // add text?
            }

            var user = await _dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Id == entity.UserId);

            if (user is null)
            {
                throw new UserNotFoundException(); // add text?
            }

            return new UserDto(user);
        }
    }
}