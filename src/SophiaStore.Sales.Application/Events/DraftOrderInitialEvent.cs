﻿using System;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class DraftOrderInitialEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }

        public DraftOrderInitialEvent(Guid clientId, Guid orderId)
        {
            AggregateId = orderId;
            ClientId = clientId;
            OrderId = orderId;
        }
    }
}
