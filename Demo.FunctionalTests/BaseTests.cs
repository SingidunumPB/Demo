using Demo.Application.Common.Interfaces;
using Demo.Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Demo.FunctionalTests;

public class BaseTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    public readonly HttpClient Client;
    public readonly DemoDbContext DemoDbContext;
    public readonly Mock<ICompanyService> MockCompanyService;

    public BaseTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
        var scope = factory.Services.CreateScope();
        DemoDbContext = scope.ServiceProvider.GetRequiredService<DemoDbContext>();
        MockCompanyService = factory.MockCompanyService;
    }
}
