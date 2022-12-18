using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeTag : IFakeGenerator<TagDto>
    {
        private readonly Faker<TagDto> _tag;
        private static HashSet<string> _uniqueTags = new();
        public FakeTag()
        {
            _tag = new Faker<TagDto>()
                .RuleFor(tag => tag.Name, (f, u) =>
        {
            var tagName = f.Random.Words();

            while (!_uniqueTags.Add(tagName))
            {
                tagName = f.Random.Words();
            }

            return f.Random.Words();
        });
        }

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
