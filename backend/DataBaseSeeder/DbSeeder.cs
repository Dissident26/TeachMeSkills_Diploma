using DataBase.Contexts;
using DataBaseSeeder.Fakers;

using Models.Entities;
using Services.DbServices;

namespace DataBaseSeeder
{
    public class DbSeeder
    {
        private readonly DbContextMain _dbContext;
        private readonly FakeUser _user = new FakeUser();
        private readonly FakePost _post = new FakePost();
        private readonly FakeComment _comment = new FakeComment();
        private readonly FakeTag _tag = new FakeTag();
        public DbSeeder(DbContextMain context)
        {
            _dbContext = context;
        }

        
        public async Task Seed()
        {
            //var usersIds = await SeedUsers(100);
            var tagsIds = await SeedTags(50);
            
            //seed db

        }

        private async Task<int[]> SeedUsers(int amount)
        {
            var users = _user.Generate(amount);

            var userServices = new UserServices(_dbContext);
            var createdUsers = await userServices.Create(users);

            return createdUsers.Select(user => user.Id).ToArray();
        }

        private async Task<int[]> SeedTags(int amount)
        {
            var tags = _tag.Generate(amount);

            var tagServices = new TagServices(_dbContext);
            var createdTags = await tagServices.Create(tags);

            return createdTags.Select(user => user.Id).ToArray();
        }
    }
}
