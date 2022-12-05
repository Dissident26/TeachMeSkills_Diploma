using Bogus;

using Models.Entities;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeUser : IFakeGenerator<User>
    {
        private readonly Faker<User> _user = new Faker<User>()
                .RuleFor(user => user.Name, (f, u) => f.Internet.UserName())
                .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(user => user.RegistrationDate, f => f.Date.Recent());
        public List<User> Generate(int amount)
        {
            return _user.Generate(amount);
        }
        public User Generate()
        {
            return _user.Generate();
        }
    }
}
