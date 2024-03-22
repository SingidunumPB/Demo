using Demo.Api.Auth.Constants;
using Demo.Application.Common.Interfaces;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Controllers;

[ApiController]
[Route("company")]
public class CompanyController(IDemoDbContext dbContext) : ControllerBase
{
    [HttpGet("details")]
    public async Task<IActionResult> Details()
    {
        var result = await dbContext.Companies
            .Include(x => x.Products)
            .ToListAsync();

        return Ok();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create()
    {
        var company = new Company(Guid.NewGuid(),
            "Tesla",
            "Tesla Company");
        dbContext.Companies.Add(company);
        await dbContext.SaveChangesAsync(new CancellationToken());
        return Ok();
    }
}