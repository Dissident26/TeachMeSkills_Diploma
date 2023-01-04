namespace Services.Exceptions
{
    public class PostTagNotFoundException : Exception
    {
        public PostTagNotFoundException()
        {
        }

        public PostTagNotFoundException(string message) : base(message)
        {
        }

        public PostTagNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
