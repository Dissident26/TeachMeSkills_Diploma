using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakePostTag : IFakeGenerator<PostTagDto>
    {
        private readonly Faker<PostTagDto> _postTag;

        public FakePostTag(int[] postIds, int[] tagIds)
        {
            _postTag = new Faker<PostTagDto>()
                .RuleFor(postTag => postTag.PostId, f => f.Random.ArrayElement(postIds))
                .RuleFor(postTag => postTag.TagId, f => f.Random.ArrayElement(tagIds));
        }

        public List<PostTagDto> Generate(int amount)
        {
            return _postTag.Generate(amount);
        }

        public PostTagDto Generate()
        {
            return _postTag.Generate();
        }
    }
}
