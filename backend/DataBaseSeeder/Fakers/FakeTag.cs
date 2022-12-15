using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeTag : IFakeGenerator<TagDto>
    {
        private readonly Faker<TagDto> _tag = new Faker<TagDto>()
        .RuleFor(tag => tag.Name, (f, u) => f.Random.Words());

        public List<TagDto> Generate(int amount)
        {
            return _tag.Generate(amount);
        }

        public TagDto Generate()
        {
            return _tag.Generate();
        }
    }
}
