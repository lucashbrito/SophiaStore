using System;
using FluentValidation.Results;
using MediatR;

namespace SophiaStore.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public ValidationResult ValidationResult { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected Command(ValidationResult validationResult, DateTime timestamp)
        {
            ValidationResult = validationResult;
            Timestamp = timestamp;
        }

        public abstract bool IsValid();
    }
}
