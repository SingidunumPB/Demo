using Demo.Api.Auth.Constants;
using Demo.Application.Products.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Webhooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class ProductWebhook : BaseWebhook
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductCreateCommand command) => Ok(await Mediator.Send(command));
}
