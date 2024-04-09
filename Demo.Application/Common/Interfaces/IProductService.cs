using Demo.Application.Common.Dto.Product;

namespace Demo.Application.Common.Interfaces;

public interface IProductService
{
    Task<ProductDetailsDto> CreateAsync(ProductCreateDto product, CancellationToken cancellationToken);
}
