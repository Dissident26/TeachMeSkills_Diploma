using Bogus;

using Models.Entities;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeTag : IFakeGenerator<Tag>
    {
        private readonly Faker<Tag> _tag = new Faker<Tag>()
        .RuleFor(tag => tag.Name, (f, u) => f.Random.Words());

        public List<Tag> Generate(int amount)
        {
            return _tag.Generate(amount);
        }

        public Tag Generate()
        {
            return _tag.Generate();
        }
    }
}
