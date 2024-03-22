﻿using Demo.Application.Configuration;
using Microsoft.AspNetCore.Authentication;

namespace Demo.Api.Auth.Options;

public class HeaderBasicAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public string UsernameHeader { get; set; } = "X-De-Username";
    public string PasswordHeader { get; set; } = "X-De-Password";
    
    public IEnumerable<HeaderBasicAuthConfiguration> Users { get; init; } = Array.Empty<HeaderBasicAuthConfiguration>();
}
