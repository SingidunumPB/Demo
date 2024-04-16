using Demo.Application.Common.Dto.Product;
using Demo.Domain.Common.Extensions;
using Demo.Domain.Enums;
using FluentValidation;

namespace Demo.Application.Common.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.CompanyId)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .MaximumLength(350);
        
        RuleFor(x => x.Category)
            .Must(t => Category.TryFromValue(t, out _))
            .WithMessage(_ => $"Category is not valid, category must be in list of: {EnumExtensions.CategoryValidList}");

    }
}
