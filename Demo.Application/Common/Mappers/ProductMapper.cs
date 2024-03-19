using Demo.Application.Common.Dto.Product;
using Demo.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Demo.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static partial ProductDetailsDto ToDto(this Product entity);
    public static partial Product FromCreateDtoToEntity(this ProductCreateDto dto);
    public static Product ToCustomDto(this ProductCreateDto dto, Company company)
    {
        var product = new Product(dto.Name, dto.Description);
        
        return product;
    }

}