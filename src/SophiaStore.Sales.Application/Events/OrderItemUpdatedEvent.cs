using System;
using System.Collections.Generic;
using System.Text;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderItemUpdatedEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public OrderItemUpdatedEvent(Guid clientId, Guid orderId, Guid productId, int quantity)
        {
            AggregateId = orderId;
            ClientId = clientId;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
