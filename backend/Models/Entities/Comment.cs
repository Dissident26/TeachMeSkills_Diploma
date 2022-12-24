using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Comment> Replies { get; set; }
    }
}
