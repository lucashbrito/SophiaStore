using System;
using FluentValidation;
using SophiaStore.Sales.Application.Commands;

namespace SophiaStore.Sales.Application.Validation
{
    public class ApplyVoucherOrderValidation : AbstractValidator<ApplyVoucherOrderCommand>
    {
        public ApplyVoucherOrderValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("The CliendId can't be empty");

            RuleFor(c => c.ProductId)
                .NotEqual(Guid.Empty)
                .WithMessage("The ProductId can't be empty");

            RuleFor(c => c.VoucherCode)
                .NotEmpty()
                .NotNull()
                .WithMessage("The VoucherCode can't be empty");
        }
    }
}