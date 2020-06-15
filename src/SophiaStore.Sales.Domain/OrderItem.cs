using System;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Sales.Domain
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string NameProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }

        //EF 
        public Order Order { get; set; }

        protected OrderItem() { }

        public OrderItem( Guid productId, string nameProduct, int quantity, decimal unitValue)
        {
            ProductId = productId;
            NameProduct = nameProduct;
            Quantity = quantity;
            UnitValue = unitValue;
        }

        public void SetOrder(Guid orderId)
        {
            OrderId = orderId;
        }

        public decimal CalculateValue()
        {
            return Quantity + UnitValue;
        }

        public void AddUnit(int unity)
        {
            Quantity += unity;
        }

        internal void UpdateQuantity(int unity)
        {
            Quantity = unity;
        }

        public override bool IsValid()
        {
            return true;
        }

    }
}