namespace web_api.Exceptions
{
    public abstract class StatusCodeException : Exception
    {
        public int StatusCode { get; private set; }

        public StatusCodeException(string message) : base(message) { }
        public StatusCodeException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : StatusCodeException
    {
        public NotFoundException(string message) : base(message, StatusCodes.Status404NotFound) { }
    }

    public class BadRequestException : StatusCodeException
    {
        public BadRequestException(string message) : base(message, StatusCodes.Status400BadRequest) { }
    }
}
