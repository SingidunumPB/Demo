using Demo.Application.Common.Exceptions;

namespace Demo.Application.Products.Exceptions;

public class ProductException : BaseException
{
    public ProductException(string message, object? additionalData = null) : base(message,
        additionalData)
    {
    }
}
