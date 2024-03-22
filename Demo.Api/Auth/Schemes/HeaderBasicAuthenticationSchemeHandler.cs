using System.Security.Claims;
using System.Text.Encodings.Web;
using Demo.Api.Auth.Options;
using Demo.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Demo.Api.Auth.Schemes;

public class HeaderBasicAuthenticationSchemeHandler : AuthenticationHandler<HeaderBasicAuthenticationSchemeOptions>
{
    private readonly IDemoDbContext _dbContext;
    
    [Obsolete("Obsolete")]
    public HeaderBasicAuthenticationSchemeHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IDemoDbContext dbContext) : base(options,
        logger,
        encoder,
        clock)
    {
        _dbContext = dbContext;
    }

    public HeaderBasicAuthenticationSchemeHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IDemoDbContext dbContext) : base(options,
        logger,
        encoder)
    {
        _dbContext = dbContext;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var username = Request.Headers[Options.UsernameHeader]
                    .FirstOrDefault() ??
                throw new InvalidOperationException("Missing Username header");
            var password = Request.Headers[Options.PasswordHeader]
                    .FirstOrDefault() ??
                throw new InvalidOperationException("Missing Username header");

            var companies = await _dbContext.Companies.ToListAsync();

            var user = Options.Users.SingleOrDefault(user => user.Username.Equals(username,
                        StringComparison.OrdinalIgnoreCase) &&
                    user.Password.Equals(password,
                        StringComparison.OrdinalIgnoreCase)) ??
                throw new InvalidOperationException("User not found");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,
                    username)
            };
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role,
                role)));
            claims.AddRange(user.Claims.Select(x => new Claim(x.Key,
                x.Value)));

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims,
                "Tokens"));
            var ticket = new AuthenticationTicket(principal,
                Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        catch (Exception e)
        {
            return AuthenticateResult.Fail("Unauthorized");
        }
    }
}
