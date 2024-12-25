using FluentValidation;
using APILayer.DTOs;

namespace APILayer.Validators;

public class CreateOrderItemDTOValidator : AbstractValidator<CreateOrderItemDTO>
{
    public CreateOrderItemDTOValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0);

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .LessThan(1000);
    }
}