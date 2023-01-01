namespace Services.Exceptions
{
    public class TagNotFoundException : Exception
    {
        public TagNotFoundException(string message = ExceptionMessages.TagNotFound) : base(message)
        {
        }

        public TagNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
