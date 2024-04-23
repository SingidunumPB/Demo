﻿using Demo.Application.Auth.Commands.BeginLoginCommand;
using Demo.Application.Auth.Commands.CompleteLoginCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

public class AuthController : ApiBaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) => Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));
}
