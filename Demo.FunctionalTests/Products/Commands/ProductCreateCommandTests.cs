using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Demo.Application.Common.Dto.Product;
using Demo.BaseTests.Builders.Commands;
using Demo.BaseTests.Builders.Domain;
using Demo.BaseTests.Builders.Dto;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;

namespace Demo.FunctionalTests.Products.Commands;

public class ProductCreateCommandTests : BaseTests
{
    [Fact]
    public async Task ProductCreateCommandTest_GivenValidProduct_StatusOk()
    {
        //Given
        var company = new CompanyBuilder().Build();

        await DemoDbContext.Companies.AddAsync(company);
        await DemoDbContext.SaveChangesAsync();

        var productDto = new ProductCreateDtoBuilder().WithCompanyId(company.Id)
            .Build();

        var product = new ProductCreateCommandBuilder().WithProductCreateDto(productDto)
            .Build();

        var jsonProduct = JsonSerializer.Serialize(product);
        var contentRequest = new StringContent(jsonProduct,
            Encoding.UTF8,
            "application/json");

        MockCompanyService.Setup(x => x.CreateAsync())
            .Returns("Test");

        //When
        var response = await Client.PostAsync("/api/Product/Create/create",
            contentRequest,
            new CancellationToken());

        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ProductDetailsDto>();

        content.Should()
            .NotBeNull();

        MockCompanyService.Verify(x => x.CreateAsync(), Times.Never);
    }

    public ProductCreateCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}
