using System;
using FluentValidation.Results;
using SophiaStore.Core.Messages;
using SophiaStore.Sales.Application.Validation;

namespace SophiaStore.Sales.Application.Commands
{
    public class CancelProcessOrderCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }

        public CancelProcessOrderCommand(ValidationResult validationResult, DateTime timestamp, Guid clientId, Guid productId)
            : base(validationResult, timestamp)
        {
            ClientId = clientId;
            ProductId = productId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CancelProcessValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
