namespace ChatAppBackend.API.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException() : base()
    {
    }
    public ResourceNotFoundException(string message) : base(message)
    {
    }
    public ResourceNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
