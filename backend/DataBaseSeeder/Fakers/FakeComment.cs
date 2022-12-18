using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakeComment : IFakeGenerator<CommentDto>
    {
        private readonly Faker<CommentDto> _comment;
        public FakeComment(int[] usersIds, int[] postIds)
        {
            _comment = new Faker<CommentDto>()
            .RuleFor(comment => comment.UserId, f => f.Random.ArrayElement(usersIds))
            .RuleFor(comment => comment.PostId, f => f.Random.ArrayElement(postIds))
            .RuleFor(comment => comment.Content, f => f.Random.Words())
            .RuleFor(comment => comment.CreationDate, f => f.Date.Recent());
        }

        public List<CommentDto> Generate(int amount)
        {
            return _comment.Generate(amount);
        }

        public CommentDto Generate()
        {
            return _comment.Generate();
        }
    }
}
