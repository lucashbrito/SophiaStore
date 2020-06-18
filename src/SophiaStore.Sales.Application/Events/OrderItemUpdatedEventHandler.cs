using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderItemUpdatedEventHandler:INotificationHandler<OrderItemUpdatedEvent>
    {
        public Task Handle(OrderItemUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
