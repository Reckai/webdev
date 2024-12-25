using FluentValidation;
using APILayer.DTOs;

namespace APILayer.Validators;

public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
{
    public CreateOrderDTOValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0);

        RuleFor(x => x.OrderItems)
            .NotEmpty()
            .WithMessage("Order must contain at least one item");

        RuleForEach(x => x.OrderItems).SetValidator(new CreateOrderItemDTOValidator());
    }
}