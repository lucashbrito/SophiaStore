using System;
using FluentValidation.Results;
using SophiaStore.Core.Messages;
using SophiaStore.Sales.Application.Validation;

namespace SophiaStore.Sales.Application.Commands
{
    public class RemoverOrderItemCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }

        public RemoverOrderItemCommand(ValidationResult validationResult, DateTime timestamp, Guid clientId, Guid productId, Guid orderId)
            : base(validationResult, timestamp)
        {
            ClientId = clientId;
            ProductId = productId;
            OrderId = orderId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}