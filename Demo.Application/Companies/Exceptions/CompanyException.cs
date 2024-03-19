using Demo.Application.Common.Exceptions;

namespace Demo.Application.Companies.Exceptions;

public class CompanyException : BaseException
{
    public CompanyException(string message, object? additionalData = null) : base(message,
        additionalData)
    {
    }
}
