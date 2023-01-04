using Bogus;
using DataBaseSeeder.Interfaces;
using Services.Dtos;
namespace DataBaseSeeder.Fakers
{
    internal class FakeRepliedComment : IFakeGenerator<RepliedCommentDto>
    {
        private readonly Faker<RepliedCommentDto> _repliedComment;
        private static HashSet<string> _uniqueRepliedComments = new();
        public FakeRepliedComment(int[] postIds, CommentDto[] comments)
        {
            _repliedComment = new Faker<RepliedCommentDto>()
                .Rules((f, o) =>
                {
                    var postId = f.Random.ArrayElement(postIds);
                    var availableCommentsIds = comments.Where(comment => comment.PostId == postId)
                    .Select(comment => comment.Id)
                    .ToList();
                    
                    var commentId = f.Random.ListItem(availableCommentsIds);
                    availableCommentsIds.Remove(commentId);
                    var repliedCommentId = f.Random.ListItem(availableCommentsIds);

                    while (!_uniqueRepliedComments.Add($"{commentId}-{repliedCommentId}"))
                    {
                        commentId = f.Random.ListItem(availableCommentsIds);
                        repliedCommentId = f.Random.ListItem(availableCommentsIds);
                    }

                    o.CommentId = commentId;
                    o.RepliedCommentId = repliedCommentId;
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
