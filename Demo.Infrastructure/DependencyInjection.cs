using Demo.Application.Common.Interfaces;
using Demo.Infrastructure.Configuration;
using Demo.Infrastructure.Contexts;
using Demo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            services.AddDbContext<DemoDbContext>(options =>
                options.UseNpgsql(dbConfiguration.ConnectionString,
                    x => x.MigrationsAssembly(typeof(DemoDbContext).Assembly.FullName)));
        }
        
        services.AddScoped<IDemoDbContext>(provider => provider.GetRequiredService<DemoDbContext>());
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICompanyService, CompanyService>();
        
        return services;
    }
}