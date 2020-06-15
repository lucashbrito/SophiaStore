using System;
using SophiaStore.Core.DomainObjects;
using SophiaStore.Core.Messages.DomainEvents;

namespace SophiaStore.Catalog.Domain.Events
{
    public class ProductLowStockEvent : DomainEvent
    {
        public int RemainingAmount { get; set; }
        public ProductLowStockEvent(Guid aggregateId, int remainingAmount) : base(aggregateId)
        {
            RemainingAmount = remainingAmount;
        }

    }
}
