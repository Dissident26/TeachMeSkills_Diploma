namespace Models.Entities
{
    public class RepliedComment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int RepliedCommentId { get; set; }
        public Comment Comment { get; set; }
        public Comment Reply { get; set; }
    }
}
