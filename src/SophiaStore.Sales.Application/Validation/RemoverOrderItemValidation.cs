using System;
using FluentValidation;
using SophiaStore.Sales.Application.Commands;

namespace SophiaStore.Sales.Application.Validation
{
    public class RemoverOrderItemValidation : AbstractValidator<RemoverOrderItemCommand>
    {
        public RemoverOrderItemValidation()
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
        }
    }
}
