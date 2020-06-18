using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Commands
{
    public class FinishOrderCommand : Command
    {
        public FinishOrderCommand(ValidationResult validationResult, DateTime timestamp) : base(validationResult, timestamp)
        {
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
