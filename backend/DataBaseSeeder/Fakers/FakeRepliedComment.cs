using Bogus;
using DataBaseSeeder.Interfaces;
using Models.Entities;
using Services.Dtos;
namespace DataBaseSeeder.Fakers
{
    internal class FakeRepliedComment : IFakeGenerator<RepliedCommentDto>
    {
        private readonly Faker<RepliedCommentDto> _repliedComment;
        public FakeRepliedComment(int[] postIds, CommentDto[] comments)
        {
            _repliedComment = new Faker<RepliedCommentDto>()
                .Rules((f, o) =>
                {
                    var postId = f.Random.ArrayElement(postIds);
                    var availableCommentsIds = comments.Where(comment => comment.PostId == postId)
                    .Select(comment => comment.Id)
                    .ToArray();

                    o.CommentId = f.Random.ArrayElement(availableCommentsIds);
                    o.RepliedCommentId = f.Random.ArrayElement(availableCommentsIds);
                });
        }
        public List<RepliedCommentDto> Generate(int amount)
        {
            return _repliedComment.Generate(amount);
        }

        public RepliedCommentDto Generate()
        {
            return _repliedComment.Generate();
        }
    }
}
