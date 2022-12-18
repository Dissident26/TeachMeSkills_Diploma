namespace Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public DateTime RegistrationDate { get; set; }

        public UserAuthModel UserAuthModel { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}