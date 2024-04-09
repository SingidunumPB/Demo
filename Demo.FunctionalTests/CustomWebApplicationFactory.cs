using Demo.Application.Common.Interfaces;
using Demo.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace Demo.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public Mock<ICompanyService> MockCompanyService { get; } = new();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DemoDbContext>();

            var dbName = Guid.NewGuid()
                .ToString();

            services.AddDbContext<DemoDbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });
            
            services.AddScoped(_ => MockCompanyService.Object);
        });
    }
}
