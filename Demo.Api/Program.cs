using Demo.Api.Auth;
using Demo.Api.Filters;
using Demo.Api.Services;
using Demo.Application;
using Demo.Domain.Common.Extensions;
using Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddNsiDemoAuthentication(builder.Configuration);

builder.Services.AddScoped<ITestProduct, TestProductOne>();
builder.Services.AddScoped<ITestProduct, TestProductTwo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


public partial class Program
{
}