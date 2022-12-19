using Services.Dtos;

namespace Services.Interfaces
{
    public interface IAuthServices
    {
        public Task Create(UserAuthModelDto model);
        public Task Update(UserAuthModelDto newModel);
        public Task Delete(int id);
        public Task<UserDto> ValidateUser(UserAuthModelDto userAuthModel);
    }
}
