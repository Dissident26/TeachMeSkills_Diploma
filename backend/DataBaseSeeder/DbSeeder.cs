using DataBase.Contexts;
using DataBaseSeeder.Fakers;

using Services.DbServices;

namespace DataBaseSeeder
{
    public class DbSeeder
    {
        private readonly DbContextMain _dbContext;
        //private readonly FakeComment _comment = new FakeComment();
        public DbSeeder(DbContextMain context)
        {
            _dbContext = context;
        }

        
        public async Task Seed()
        {
            int numberOfPosts = 100;

            var usersIds = await SeedUsers(100);
            var tagsIds = await SeedTags(50);
            var postsIds = await SeedPosts(numberOfPosts, usersIds);
            await SeedPostTags(numberOfPosts, postsIds, tagsIds);
        }
        private async Task<int[]> SeedUsers(int amount)
        {
            FakeUser fakeUserModel = new FakeUser();
            var users = fakeUserModel.Generate(amount);

            var userServices = new UserServices(_dbContext);
            var createdUsers = await userServices.Create(users);

            return createdUsers.Select(user => user.Id).ToArray();
        }
        private async Task<int[]> SeedTags(int amount)
        {
            FakeTag fakeTagModel = new FakeTag();
            var tags = fakeTagModel.Generate(amount);

            var tagServices = new TagServices(_dbContext);
            var createdTags = await tagServices.Create(tags);

            return createdTags.Select(user => user.Id).ToArray();
        }
        private async Task<int[]> SeedPosts(int amount, int[] usersIds)
        {
            FakePost fakePostModel = new FakePost(usersIds);
            var posts = fakePostModel.Generate(amount);

            var postServices = new PostServices(_dbContext);
            var createdPosts = await postServices.Create(posts);

            return createdPosts.Select(post => post.Id).ToArray();
        }
        private async Task SeedPostTags(int amount, int[] postsIds, int[] tagsIds)
        {
            FakePostTag fakePostTagModel = new FakePostTag(postsIds, tagsIds);
            var postTags = fakePostTagModel.Generate(amount);

            var postTagServices = new PostTagServices(_dbContext);
            await postTagServices.Create(postTags);
        }
    }
}
