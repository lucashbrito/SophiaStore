using System;
using System.Collections.Generic;
using System.Text;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderItemRemovedEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        public OrderItemRemovedEvent(Guid clientId, Guid orderId, Guid productId)
        {
            AggregateId = orderId;
            ClientId = clientId;
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
