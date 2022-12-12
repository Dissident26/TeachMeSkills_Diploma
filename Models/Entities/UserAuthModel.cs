namespace Models.Entities
{
    public class UserAuthModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User User { get; set; }  
    }
}
