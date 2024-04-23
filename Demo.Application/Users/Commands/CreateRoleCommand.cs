using Demo.Application.Common.Interfaces;
using MediatR;

namespace Demo.Application.Users.Commands;

public record CreateUserCommand(string EmailAddress, List<string> Roles) : IRequest;

public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken) => await userService.CreateUserAsync(request.EmailAddress,
        request.Roles);
}
