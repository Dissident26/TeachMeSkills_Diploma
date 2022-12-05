using Bogus;

using Models.Entities;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakePost : IFakeGenerator<Post>
    {
        private readonly Faker<Post> _post;

        public FakePost(int[] usersIds)
        {
            _post = new Faker<Post>()
                .RuleFor(post => post.Content, f => f.Lorem.Paragraphs(f.Random.Int(1, 3)))
                .RuleFor(post => post.CreationDate, f => f.Date.Recent())
                .RuleFor(post => post.UserId, f => f.Random.ArrayElement(usersIds));
        }

        public List<Post> Generate(int amount)
        {
            return _post.Generate(amount);
        }

        public Post Generate()
        {
            return _post.Generate();
        }
    }
}
