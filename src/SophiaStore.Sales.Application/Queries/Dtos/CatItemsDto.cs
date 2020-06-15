using System;

namespace SophiaStore.Sales.Application.Queries.Dtos
{
    public class CatItemsDto
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnityValue { get; set; }
        public decimal TotalValue { get; set; }

        public static CatItemsDto Create(Guid productId, string nameProduct, in int quantity, in decimal unitValue, decimal totalValue)
        {
            return new CatItemsDto()
            {
                ProductID = productId,
                ProductName = nameProduct,
                Quantity = quantity,
                UnityValue = unitValue,
                TotalValue = totalValue
            };
        }
    }
}