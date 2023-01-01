namespace Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = ExceptionMessages.UserNotFound) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
