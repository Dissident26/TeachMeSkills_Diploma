using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeUser : IFakeGenerator<UserDto>
    {
        private readonly Faker<UserDto> _user = new Faker<UserDto>()
                .RuleFor(user => user.Name, (f, u) => f.Internet.UserName())
                .RuleFor(user => user.Avatar, (f, u) => f.Internet.Avatar())
                .RuleFor(user => user.RegistrationDate, f => f.Date.Recent());
        public List<UserDto> Generate(int amount)
        {
            return _user.Generate(amount);
        }
        public UserDto Generate()
        {
            return _user.Generate();
        }
    }
}
