using FluentValidation;
using APILayer.DTOs;

namespace APILayer.Validators;

public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
{
    public CreateProductDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .LessThan(1000000);
    }
}