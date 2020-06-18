using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;

namespace SophiaStore.Sales.Application.Commands
{
    public class StartOrderCommandHandler : BaseCommandHandler, IRequestHandler<StartOrderCommand, bool>
    {
        public StartOrderCommandHandler(IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
        }

        public Task<bool> Handle(StartOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
