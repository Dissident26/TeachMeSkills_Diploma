namespace Services.Exceptions
{
    public class TagNotFoundException : Exception
    {
        public TagNotFoundException()
        {
        }

        public TagNotFoundException(string message) : base(message)
        {
        }

        public TagNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
