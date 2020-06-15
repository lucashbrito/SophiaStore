using System;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class AddOrderItemEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal Value { get; private set; }
        public int Quantity { get; private set; }

        public AddOrderItemEvent(Guid clientId, Guid orderId, Guid productId, decimal value, int quantity)
        {
            AggregateId = orderId;
            ClientId = clientId;
            OrderId = orderId;
            ProductId = productId;
            Value = value;
            Quantity = quantity;
        }

    }
}