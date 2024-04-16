using System.Net;
using System.Net.Http.Json;
using Demo.Application.Common.Dto.Product;
using Demo.BaseTests.Builders.Domain;
using Demo.Domain.Entities;
using Demo.Domain.Enums;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Demo.FunctionalTests.Products.Queries;

public class ProductDetailsQueryTests : BaseTests
{
    [Fact]
    public async Task ProductDetailsQueryTest_GivenValidProductId_StatusOk()
    {
        //Given
        var company = new CompanyBuilder().Build();
        var product = new ProductBuilder()
            .WithDescription("bilo koji description")
            .Build()
            .AddCompany(company);

        await DemoDbContext.Products.AddAsync(product);
        await DemoDbContext.SaveChangesAsync();

        //When
        var response = await Client.GetAsync($"/api/Product/Details?Id={product.Id.ToString()}");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ProductDetailsDto>();

        content.Should()
            .NotBeNull();

        content!.Name
            .Should()
            .Be(product.Name);

        content.CompanyName
            .Should()
            .Be(company.Name);
    }

    [Fact]
    public async Task ProductDetailsQueryTest_GivenProductIdAsNull_BadRequest()
    {
        //Given

        //When
        var response = await Client.GetAsync("/api/Product/Details");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ProductDetailsQueryTest_GivenNotExistingProductId_NotFound()
    {
        //Given
        var company = new Company("-",
            "-");
        var product = new Product("-",
            "-", Category.Tehnika).AddCompany(company);

        await DemoDbContext.Products.AddAsync(product);
        await DemoDbContext.SaveChangesAsync();

        //When
        var response = await Client.GetAsync($"/api/Product/Details?Id={Guid.NewGuid()}");

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    public ProductDetailsQueryTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}
