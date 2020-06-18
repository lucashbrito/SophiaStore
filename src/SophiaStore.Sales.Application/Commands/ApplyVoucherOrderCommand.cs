using System;
using FluentValidation.Results;
using SophiaStore.Core.Messages;
using SophiaStore.Sales.Application.Validation;

namespace SophiaStore.Sales.Application.Commands
{
    public class ApplyVoucherOrderCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public string VoucherCode { get; private set; }

        public ApplyVoucherOrderCommand(ValidationResult validationResult, DateTime timestamp, Guid clientId, Guid productId, string voucherCode) : base(validationResult, timestamp)
        {
            ClientId = clientId;
            ProductId = productId;
            VoucherCode = voucherCode;
        }


        public override bool IsValid()
        {
            ValidationResult = new ApplyVoucherOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}