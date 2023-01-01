namespace Services.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(string message = ExceptionMessages.PostNotFound) : base(message)
        {
        }

        public PostNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
