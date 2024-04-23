using Demo.Application.Common.Dto.Auth;
using Demo.Application.Common.Interfaces;
using MediatR;

namespace Demo.Application.Auth.Commands.CompleteLoginCommand;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;

public class CompleteLoginHandler(IAuthService authService) : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken) => await authService.CompleteLoginAsync(request.ValidationToken);
}
