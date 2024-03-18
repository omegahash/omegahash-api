namespace Omegahash.Shared.Exceptions;

public abstract class BadRequestException(string message) : ApplicationException("Bad Request", message)
    {
}
