using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;

namespace SophiaStore.Sales.Application.Commands
{
    public class FinishOrderCommandHandler : BaseCommandHandler, IRequestHandler<FinishOrderCommand, bool>
    {
        public FinishOrderCommandHandler(IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
        }

        public Task<bool> Handle(FinishOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
