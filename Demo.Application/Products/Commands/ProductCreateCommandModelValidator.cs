using Demo.Application.Common.Validators;
using FluentValidation;

namespace Demo.Application.Products.Commands;

public class ProductCreateCommandModelValidator : AbstractValidator<ProductCreateCommand>
{
    public ProductCreateCommandModelValidator()
    {
        RuleFor(x => x.Product)
            .SetValidator(new ProductCreateDtoValidator());
    }
}

