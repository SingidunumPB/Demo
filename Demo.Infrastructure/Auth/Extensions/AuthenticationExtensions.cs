﻿using Demo.Infrastructure.Auth.Providers;
using Microsoft.AspNetCore.Identity;

namespace Demo.Infrastructure.Auth.Extensions;

public static class AuthenticationExtensions
{
    public static IdentityBuilder AddPasswordlessLoginTokenProvider(this IdentityBuilder builder)
    {
        var userType = builder.UserType;
        var provider = typeof(PasswordlessLoginTokenProvider<>).MakeGenericType(userType);
        return builder.AddTokenProvider("PasswordlessLoginTokenProvider", provider);
    }
}
