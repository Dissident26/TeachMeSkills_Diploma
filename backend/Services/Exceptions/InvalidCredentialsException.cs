namespace Services.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message = ExceptionMessages.InvalidCredentials) : base(message)
        {
        }

        public InvalidCredentialsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}