using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SophiaStore.Sales.Application.Queries.Dtos;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueries(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CatDto> GetCatClient(Guid clientId)
        {
            var order = await _orderRepository.GetDraftOrderByClientId(clientId);

            if (order == null) return null;

            var cat = CatDto.Create(order.ClientId, order.TotalValue, order.Id, order.Discount,
                order.Discount + order.TotalValue);

            if (order.VoucherId != null) cat.VoucherCode = order.Voucher.Code;

            foreach (var item in order.OrderItems)
            {
                cat.Items.Add(CatItemsDto.Create(item.ProductId, item.NameProduct, item.Quantity, item.UnitValue, item.UnitValue * item.Quantity));
            }

            return cat;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersClient(Guid clientId)
        {
            var orders = await _orderRepository.GetOrderByClientId(clientId);

            orders = orders.Where(o => o.OrderStatus == OrderStatus.Paid
                                       || o.OrderStatus == OrderStatus.Canceled).OrderByDescending(o => o.Code).ToList();

            if (!orders.Any()) return null;

            return orders.Select(order => OrderDto.Create(order.TotalValue, (int) order.OrderStatus, order.Code, order.CreatedDate)).ToList();
        }
    }
}