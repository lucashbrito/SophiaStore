using System;
using FluentValidation;
using SophiaStore.Sales.Application.Commands;

namespace SophiaStore.Sales.Application.Validation
{
    public class UpdateOrderItemValidation : AbstractValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("The CliendId can't be empty");

            RuleFor(c => c.ProductId)
                .NotEqual(Guid.Empty)
                .WithMessage("The ProductId can't be empty");


            RuleFor(c => c.OrderId)
                .NotEqual(Guid.Empty)
                .WithMessage("The OrderId can't be empty");

            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("The quantity should be more than 0");

            RuleFor(c => c.Quantity)
                .LessThan(15)
                .WithMessage("The quantity should be less than 15");
        }
    }
}
