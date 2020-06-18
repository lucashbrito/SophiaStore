using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SophiaStore.Sales.Application.Events
{
    public class DraftOrderInitialEventHandler: INotificationHandler<DraftOrderInitialEvent>
    {
        public Task Handle(DraftOrderInitialEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
