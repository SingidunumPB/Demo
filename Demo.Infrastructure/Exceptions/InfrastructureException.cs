using Demo.Application.Common.Exceptions;

namespace Demo.Infrastructure.Exceptions;

public class InfrastructureException(string message, object? additionalData = null) : BaseException(message,
    additionalData);
