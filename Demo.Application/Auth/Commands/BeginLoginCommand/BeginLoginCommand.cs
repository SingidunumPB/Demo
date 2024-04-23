using Demo.Application.Common.Dto.Auth;
using Demo.Application.Common.Interfaces;
using MediatR;

namespace Demo.Application.Auth.Commands.BeginLoginCommand;

public record BeginLoginCommand(string EmailAddress) : IRequest<BeginLoginResponseDto>;

public class BeginLoginHandler(IAuthService authService) : IRequestHandler<BeginLoginCommand, BeginLoginResponseDto>
{
    public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken) => await authService.BeginLoginAsync(request.EmailAddress);
}
