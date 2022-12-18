using Bogus;

using Services.Dtos;
using DataBaseSeeder.Interfaces;

namespace DataBaseSeeder.Fakers
{
    public class FakePostTag : IFakeGenerator<PostTagDto>
    {
        private readonly Faker<PostTagDto> _postTag;
        private static HashSet<string> _uniquePostTags = new();
        public FakePostTag(int[] postIds, int[] tagIds)
        {
            

            _postTag = new Faker<PostTagDto>().Rules((f, o) =>
            {
                var postId = f.Random.ArrayElement(postIds);
                var tagId = f.Random.ArrayElement(tagIds);

                while (!_uniquePostTags.Add($"{postId}-{tagId}"))
                {
                    postId = f.Random.ArrayElement(postIds);
                    tagId = f.Random.ArrayElement(tagIds);
                }

                o.PostId = postId;
                o.TagId = tagId;
            });
                
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

