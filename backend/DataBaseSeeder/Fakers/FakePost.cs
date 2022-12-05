using Bogus;

using Models.Entities;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakePost : IFakeGenerator<Post>
    {
        private readonly Faker<Post> _post = new Faker<Post>()
        .RuleFor(user => user.Content, f => f.Lorem.Paragraphs(f.Random.Int(1, 3)))
        .RuleFor(user => user.CreationDate, f => f.Date.Recent());

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
