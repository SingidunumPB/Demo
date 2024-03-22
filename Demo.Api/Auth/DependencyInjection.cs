using Demo.Api.Auth.Constants;
using Demo.Api.Auth.Options;
using Demo.Api.Auth.Schemes;

namespace Demo.Api.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddNsiDemoAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthenticationSchemeOptions, HeaderBasicAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header")
                    .Bind(schemeOptions));
        
        // services.AddAuthentication()
        //     .AddScheme<JwtAuthenticationSchemeOptions, JwtAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
        //         schemeOptions => configuration.GetSection("Auth:Header")
        //             .Bind(schemeOptions));

        return services;
    }
}
