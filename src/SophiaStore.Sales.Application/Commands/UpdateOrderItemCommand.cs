using System;
using FluentValidation.Results;
using SophiaStore.Core.Messages;
using SophiaStore.Sales.Application.Validation;

namespace SophiaStore.Sales.Application.Commands
{
    public class UpdateOrderItemCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }
        public int Quantity { get; private set; }


        public UpdateOrderItemCommand(ValidationResult validationResult, DateTime timestamp, Guid clientId, Guid productId, Guid orderId, int quantity)
            : base(validationResult, timestamp)
        {
            ClientId = clientId;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}