using Demo.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Demo.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
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
        });
    }
}
