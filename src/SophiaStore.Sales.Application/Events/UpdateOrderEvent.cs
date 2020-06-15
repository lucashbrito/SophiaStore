using System;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class UpdateOrderEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Value { get; private set; }
        public UpdateOrderEvent(Guid clientId, Guid orderId, decimal value)
        {
            AggregateId = orderId;
            ClientId = clientId;
            OrderId = orderId;
            Value = value;
            
        }

    }
}