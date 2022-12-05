using Bogus;

using Models.Entities;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakePostTag : IFakeGenerator<PostTag>
    {
        private readonly Faker<PostTag> _postTag;

        public FakePostTag(int[] postIds, int[] tagIds)
        {
            _postTag = new Faker<PostTag>()
                .RuleFor(postTag => postTag.PostId, f => f.Random.ArrayElement(postIds))
                .RuleFor(postTag => postTag.TagId, f => f.Random.ArrayElement(tagIds));
        }

        public List<PostTag> Generate(int amount)
        {
            return _postTag.Generate(amount);
        }

        public PostTag Generate()
        {
            return _postTag.Generate();
        }
    }
}
