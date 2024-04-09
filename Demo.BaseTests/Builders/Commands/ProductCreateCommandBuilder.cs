using Demo.Application.Common.Dto.Product;
using Demo.Application.Products.Commands;
using Demo.BaseTests.Builders.Dto;

namespace Demo.BaseTests.Builders.Commands;

public class ProductCreateCommandBuilder
{
    private ProductCreateDto _productCreateDto = new ProductCreateDtoBuilder().Build();
    
    public ProductCreateCommand Build() => new(_productCreateDto);
    
    public ProductCreateCommandBuilder WithProductCreateDto(ProductCreateDto productCreateDto)
    {
        _productCreateDto = productCreateDto;
        return this;
    }

}
