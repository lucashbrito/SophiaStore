using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Sales.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        public int Code { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUpdated { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalValue { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private readonly List<OrderItem> _orderItems;

        //EF
        public Voucher Voucher { get; private set; }

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(Guid clientId, bool voucherUpdated, decimal discount, decimal totalValue)
        {
            ClientId = clientId;
            VoucherUpdated = voucherUpdated;
            Discount = discount;
            TotalValue = totalValue;
            _orderItems = new List<OrderItem>();
        }

        public void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(p => p.CalculateValue());
            CalculateDiscountTotalValue();
        }

        public bool OrdemItemExsitent(OrderItem item)
        {
            return _orderItems.Any(p => p.ProductId == item.ProductId);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (!orderItem.IsValid()) return;

            orderItem.SetOrder(Id);

            if (OrdemItemExsitent(orderItem))
            {
                var existentOrderItem = _orderItems.FirstOrDefault(p => p.ProductId == orderItem.ProductId);
                existentOrderItem.AddUnit(existentOrderItem.Quantity);
                orderItem = existentOrderItem;

                _orderItems.Remove(existentOrderItem);
            }

            orderItem.CalculateValue();
            _orderItems.Add(orderItem);

            CalculateOrderValue();
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (!orderItem.IsValid()) return;

            var existentOrderItem = GetOrderItem(orderItem);

            _orderItems.Remove(existentOrderItem);

            CalculateOrderValue();
        }

        private OrderItem GetOrderItem(OrderItem orderItem)
        {
            var existentOrderItem = GetOrderItem(orderItem);

            _orderItems.Remove(existentOrderItem);

            _orderItems.Add(existentOrderItem);

            return existentOrderItem;
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            if (!orderItem.IsValid()) return;

            orderItem.SetOrder(Id);

            var existentOrderItem = OrderItems.FirstOrDefault(p => p.ProductId == orderItem.ProductId);

            if (existentOrderItem == null) throw new DomainException("Item doesn't belong the order");

        }

        public void UpdateQuantity(OrderItem orderItem, int unity)
        {
            orderItem.UpdateQuantity(unity);
            UpdateOrderItem(orderItem);
        }

        public void CalculateDiscountTotalValue()
        {
            if (!VoucherUpdated) return;

            decimal discount = 0;
            var value = TotalValue;

            if (Voucher.DiscountVoucherType == DiscountType.Percentage)
            {
                if (Voucher.Percentage.HasValue)
                {
                    discount = (value * Voucher.Percentage.Value) / 100;
                    value -= discount;
                }
            }
            else
            {
                if (Voucher.Percentage.HasValue)
                {
                    discount = Voucher.Percentage.Value;
                    value -= discount;
                }
            }

            TotalValue = value < 0 ? 0 : value;
            Discount = discount;
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }


        public static class OrderFactory
        {
            public static Order NewOrderDraft(Guid clientId)
            {
                return new Order()
                {
                    ClientId = clientId,
                    OrderStatus = OrderStatus.Draft
                };
            }
        }
    }
}
