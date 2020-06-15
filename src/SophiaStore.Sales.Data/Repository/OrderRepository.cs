using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SophiaStore.Core.Data;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SaleContext _context;

        public OrderRepository(SaleContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _context.Order.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrderByClientId(Guid clientId)
        {
            return await _context.Order.Where(o => o.ClientId == clientId).ToListAsync();
        }

        public async Task<Order> GetDraftOrderByClientId(Guid clienteId)
        {
            var pedido = await _context.Order.FirstOrDefaultAsync(p => p.ClientId == clienteId && p.OrderStatus == OrderStatus.Draft);
            if (pedido == null) return null;

            await _context.Entry(pedido)
                .Collection(i => i.OrderItems).LoadAsync();

            if (pedido.VoucherId != null)
            {
                await _context.Entry(pedido)
                    .Reference(i => i.Voucher).LoadAsync();
            }

            return pedido;
        }

        public void Add(Order pedido)
        {
            _context.Order.Add(pedido);
        }

        public void Update(Order pedido)
        {
            _context.Order.Update(pedido);
        }


        public async Task<OrderItem> GetOrderItemById(Guid id)
        {
            return await _context.OrderItem.FindAsync(id);
        }

        public async Task<OrderItem> GetOrderItemByOrder(Guid orderId, Guid productId)
        {
            return await _context.OrderItem.FirstOrDefaultAsync(p => p.ProductId == productId && p.OrderId == orderId);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItem.Update(orderItem);
        }
        public void RemoveOrderItem(OrderItem orderItem)
        {
            _context.OrderItem.Remove(orderItem);
        }

        public async Task<Voucher> GetVoucherByCode(string code)
        {
            return await _context.Voucher.FirstOrDefaultAsync(p => p.Code == code);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
