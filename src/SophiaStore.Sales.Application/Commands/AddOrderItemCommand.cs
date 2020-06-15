using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using SophiaStore.Core.Messages;

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
