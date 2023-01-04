namespace Services.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(string message = ExceptionMessages.CommentNotFound) : base(message)
        {
        }

        public CommentNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
