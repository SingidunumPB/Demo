using Demo.Application.Common.Dto.Product;
using Demo.Domain.Entities;
using Demo.Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace Demo.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static ProductDetailsDto ToDto(this Product entity)
    {
        var dto = new ProductDetailsDto(entity.Name,
            entity.Description,
            entity.Company.Name,
            entity.Company.Description,
            entity.Category.Name,
            entity.Category
                .Subcategories
                .Select(x => x.Name)
                .ToList());
        return dto;
    }
    public static Product FromCreateDtoToEntity(this ProductCreateDto dto)
    {
        var product = new Product(dto.Name,
            dto.Description,
            Category.FromValue(dto.Category));
        return product;
    }

    public static Product ToCustomDto(this ProductCreateDto dto, Company company, Category category)
    {
        var product = new Product(dto.Name,
            dto.Description,
            category);

        return product;
    }
}
