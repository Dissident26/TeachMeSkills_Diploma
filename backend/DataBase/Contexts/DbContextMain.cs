using Microsoft.EntityFrameworkCore;

using DataBase.Constants;
using DataBase.Configurations;
using Models.Entities;

namespace DataBase.Contexts
{
    public class DbContextMain : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserAuthModel> AuthorisedUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<RepliedComment> RepliedComments { get; set; }
        public DbContextMain() 
        { }
        public DbContextMain(DbContextOptions contextOptions) : base(contextOptions) 
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = DbConstants.GetConnectionString();

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new RepliedCommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserAuthModelConfiguration()); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
