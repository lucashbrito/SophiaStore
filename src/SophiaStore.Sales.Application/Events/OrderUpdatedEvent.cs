using System;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderUpdatedEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Value { get; private set; }
        public OrderUpdatedEvent(Guid clientId, Guid orderId, decimal value)
        {
            AggregateId = orderId;
            ClientId = clientId;
            OrderId = orderId;
            Value = value;
            
        }

    }
}