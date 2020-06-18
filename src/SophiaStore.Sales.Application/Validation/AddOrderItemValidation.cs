using System;
using FluentValidation;
using SophiaStore.Sales.Application.Commands;

namespace SophiaStore.Sales.Application.Validation
{
    public class AddOrderItemValidation : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("The CliendId can't be empty");

            RuleFor(c => c.ProductId)
                .NotEqual(Guid.Empty)
                .WithMessage("The ProductId can't be empty");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("The Name can't be empty");

            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("The quantity should be more than 0");

            RuleFor(c => c.Quantity)
                .LessThan(15)
                .WithMessage("The quantity should be less than 15");

            RuleFor(c => c.Value)
                .GreaterThan(0)
                .WithMessage("The Value should be more than 0");
        }
    }
}