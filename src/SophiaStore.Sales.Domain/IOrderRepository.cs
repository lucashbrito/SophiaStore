using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SophiaStore.Core.Data;

namespace SophiaStore.Sales.Domain
{
    public interface IOrderRepository:  IRepository<Order>
    {
        Task<Order> GetOrderById(Guid id);
        Task<IEnumerable<Order>> GetOrderByClientId(Guid clientId);
        Task<Order> GetDraftOrderByClientId(Guid clientId);
        void Add(Order order);
        void Update(Order order);

        Task<OrderItem> GetOrderItemById(Guid id);
        Task<OrderItem> GetOrderItemByOrder(Guid orderId, Guid productId);
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void RemoveOrderItem(OrderItem orderItem);

        Task<Voucher> GetVoucherByCode(string code);
    }
}