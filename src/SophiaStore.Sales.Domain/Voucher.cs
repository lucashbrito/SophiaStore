using System;
using System.Collections;
using System.Collections.Generic;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Sales.Domain
{
    public class Voucher : Entity
    {
        public string Code { get; private set; }
        public decimal? Percentage { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public DiscountType DiscountVoucherType { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UsedDate { get; private set; }
        public DateTime ExpireDate { get; private set; }

        protected Voucher() { }
        //ef
        public ICollection<Order> Order { get; set; }
    }
}