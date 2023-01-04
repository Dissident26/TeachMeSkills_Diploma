using Models.Entities;
using Services.Interfaces;

namespace Services.Dtos
{
    public class UserAuthModelDto : IToEntityMapper<UserAuthModel>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserAuthModel MapToEntity()
        {
            return new UserAuthModel
            {
                Id = Id,
                Name = Name,
                Password = Password,
                UserId = UserId,
            };
        }
    }
}
