using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakePost : IFakeGenerator<PostDto>
    {
        private readonly Faker<PostDto> _post;

        public FakePost(int[] usersIds)
        {
            _post = new Faker<PostDto>()
                .RuleFor(post => post.Content, f => f.Lorem.Paragraphs(f.Random.Int(1, 3)))
                .RuleFor(post => post.CreationDate, f => f.Date.Recent())
                .RuleFor(post => post.UserId, f => f.Random.ArrayElement(usersIds));
        }

        public List<PostDto> Generate(int amount)
        {
            return _post.Generate(amount);
        }

        public PostDto Generate()
        {
            return _post.Generate();
        }
    }
}
