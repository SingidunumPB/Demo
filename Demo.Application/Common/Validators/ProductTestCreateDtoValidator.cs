using Demo.Application.Common.Dto.Product;
using Demo.Application.Products.Commands;
using Demo.Domain.Common.Extensions;
using Demo.Domain.Enums;
using FluentValidation;

namespace Demo.Application.Common.Validators;

public class ProductTestCreateDtoValidator : AbstractValidator<ProductTestCreateDto>
{
    public ProductTestCreateDtoValidator()
    {
        RuleFor(x => x.Json)
            .Must(t => t.TryDeserializeJson<ProductCreateCommand>(out _,
                SerializerExtensions.SettingsWebOptions))
            .WithMessage("Json is not in good format");

    }
}
