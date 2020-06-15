using System;
using System.Collections.Generic;

namespace SophiaStore.Sales.Application.Queries.Dtos
{
    public class CatDto
    {
        public Guid OrderId { get; set; }
        public Guid ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public decimal DiscountValue { get; set; }                                      
        public DateTime CreatedDate { get; set; }
        public int OrderStatus { get; set; }

        public decimal SubTotalValue { get; set; }


        public List<CatItemsDto> Items { get; set; } = new List<CatItemsDto>();

        public CatPaymentDto Payment { get; set; }
        public string VoucherCode { get; set; }

        public static CatDto Create(Guid clientId, in decimal totalValue, Guid orderId, in decimal discount, decimal subTotalValue)
        {
            return new CatDto()
            {
                ClientId = clientId,
                TotalValue = totalValue,
                OrderId = orderId,
                DiscountValue = discount,
                SubTotalValue = subTotalValue
            };
        }
    }
}