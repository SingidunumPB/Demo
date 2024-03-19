using FluentValidation;

namespace Demo.Application.Products.Queries;

public class ProductDetailsQueryModelValidator : AbstractValidator<ProductDetailsQuery>
{
    public ProductDetailsQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id ne moze biti prazan")
            .MinimumLength(3);
    }
}

