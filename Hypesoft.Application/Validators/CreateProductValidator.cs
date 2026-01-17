using FluentValidation;
using Hypesoft.Application.Commands.CreateProduct;

namespace Hypesoft.Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Product.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Product.Price)
            .GreaterThan(0);

        RuleFor(x => x.Product.Stock)
            .GreaterThanOrEqualTo(0);
    }
}
