﻿using System;
using FluentValidation.Results;
using SophiaStore.Core.Messages;
using SophiaStore.Sales.Application.Validation;

namespace SophiaStore.Sales.Application.Commands
{
    public class AddOrderItemCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }

        public AddOrderItemCommand(ValidationResult validationResult, DateTime timestamp, Guid clientId, Guid productId, string name, int quantity, decimal value) : base(validationResult, timestamp)
        {
            ClientId = clientId;
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
