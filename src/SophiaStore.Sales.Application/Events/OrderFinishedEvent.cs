using System;
using System.Collections.Generic;
using System.Text;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderFinishedEvent : Event
    {
        public Guid OrderId { get; private set; }

        public OrderFinishedEvent(Guid orderId)
        {
            OrderId = orderId;
            AggregateId = orderId;
        }
    }
}
