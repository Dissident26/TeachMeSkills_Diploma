using Models.Entities;
using Services.Interfaces;

namespace Services.Dtos
{
    public class UserAuthModelDto : IToEntityMapper<UserAuthModel>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserAuthModel MapToEntity()
        {
            return new UserAuthModel
            {
                Id = Id,
                Email = Email,
                Password = Password,
                UserId = UserId
            };
        }
    }
}
