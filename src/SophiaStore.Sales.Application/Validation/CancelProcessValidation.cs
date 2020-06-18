using System;
using FluentValidation;
using SophiaStore.Sales.Application.Commands;

namespace SophiaStore.Sales.Application.Validation
{
    public class CancelProcessValidation : AbstractValidator<CancelProcessOrderCommand>
    {
        public CancelProcessValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProductId)
                .NotEmpty()
                .WithMessage("Id do cliente inválido");
        }
    }
}