﻿using System;
using SophiaStore.Core.Messages;

namespace SophiaStore.Sales.Application.Events
{
    public class OrderVoucherAppliedEvent : Event
    {
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid VoucherId { get; private set; }

        public OrderVoucherAppliedEvent(Guid clientId, Guid orderId, Guid voucherId)
        {
            ClientId = clientId;
            OrderId = orderId;
            VoucherId = voucherId;
        }
    }
}
