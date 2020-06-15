using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderEventHandler:
        INotificationHandler<InitialDraftOrderEvent>, 
        INotificationHandler<UpdateOrderEvent>,
        INotificationHandler<AddOrderItemEvent>
    {
        public Task Handle(InitialDraftOrderEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdateOrderEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AddOrderItemEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
