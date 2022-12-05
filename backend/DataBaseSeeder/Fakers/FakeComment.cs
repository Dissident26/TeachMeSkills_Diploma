using Bogus;

using Models.Entities;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeComment : IFakeGenerator<Comment>
    {
        private readonly Faker<Comment> _comment = new Faker<Comment>()
            .RuleFor(comment => comment.Content, (f, u) => f.Random.Words())
            .RuleFor(comment => comment.CreationDate, f => f.Date.Recent());

        public List<Comment> Generate(int amount)
        {
            return _comment.Generate(amount);
        }

        public Comment Generate()
        {
            return _comment.Generate();
        }
    }
}
