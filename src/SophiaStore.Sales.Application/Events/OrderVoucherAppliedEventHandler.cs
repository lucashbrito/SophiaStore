using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderVoucherAppliedEventHandler: INotificationHandler<OrderVoucherAppliedEvent>
    {
        public Task Handle(OrderVoucherAppliedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
