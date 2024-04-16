using Demo.Application.Common.Dto.Product;
using Demo.Application.Common.Exceptions;
using Demo.Application.Common.Extensions;
using Demo.Application.Common.Interfaces;
using Demo.Application.Common.Mappers;
using Demo.Domain.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Products.Queries;

public record ProductDetailsQuery(string Id) : IRequest<ProductDetailsDto>;

public class ProductDetailsQueryHandler(IDemoDbContext dbContext) : IRequestHandler<ProductDetailsQuery, ProductDetailsDto>
{
    public async Task<ProductDetailsDto> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Products
            .Include(x => x.Company)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (result == null)
            throw new NotFoundException("Product not found",
                new { request.Id });

        var dto = result.ToDto();
        
        // var testJson = dto.Serialize(SerializerExtensions.DefaultOptions);
        // var testJson2 = dto.Serialize(SerializerExtensions.SettingsWebOptions);
        // var testJson3 = dto.Serialize(SerializerExtensions.SettingsHardwareOptions);
        //
        // var deserializationDto = testJson.Deserialize<ProductDetailsDto>(SerializerExtensions.DefaultOptions);
        // var deserializationDto2 = testJson2.Deserialize<ProductDetailsDto>(SerializerExtensions.SettingsWebOptions);
        // var deserializationDto3 = testJson3.Deserialize<ProductDetailsDto>(SerializerExtensions.SettingsHardwareOptions);
        //
        // var validateResult = await new ProductDetailsQueryModelValidator().ValidateAsync(request,
        //     cancellationToken);
        //
        // if (!validateResult.IsValid)
        //     throw new ValidationException(validateResult.Errors.ToGroup());
        
        return dto;
    }
}
