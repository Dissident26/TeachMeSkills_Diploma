using Services.Interfaces;
using Models.Entities;

namespace Services.Dtos
{
    public class UserDto : IToEntityMapper<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public DateTime RegistrationDate { get; set; }
        public UserDto() { }
        public UserDto(User entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Avatar = entity.Avatar;
            RegistrationDate = entity.RegistrationDate;
        }
        public User MapToEntity()
        {
            return new User
            {
                Id = Id,
                Name = Name,
                Avatar = Avatar,
                RegistrationDate = RegistrationDate
            };
        }
    }
}