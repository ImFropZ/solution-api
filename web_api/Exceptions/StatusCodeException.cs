namespace web_api.Exceptions
{
    public abstract class StatusCodeException : Exception
    {
        public StatusCodeException(string message) : base(message) { }
    }

    public class NotFoundException : StatusCodeException
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class BadRequestException : StatusCodeException
    {
        public BadRequestException(string message) : base(message) { }
    }
}
