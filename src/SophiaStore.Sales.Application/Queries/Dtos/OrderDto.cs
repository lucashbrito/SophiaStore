using System;
using System.Text;

namespace SophiaStore.Sales.Application.Queries.Dtos
{
    public class OrderDto
    {
        public int Code { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderStatus { get; set; }

        public static OrderDto Create(in decimal totalValue, int orderStatus, in int code, in DateTime createdDate)
        {
            return new OrderDto
            {
                Value = totalValue,
                OrderStatus = (int)orderStatus,
                Code = code,
                CreatedDate = createdDate
            };
        }
    }
}
