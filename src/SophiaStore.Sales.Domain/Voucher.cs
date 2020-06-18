using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
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
        public bool Active { get; private set; }
        public bool Used { get; private set; }

        protected Voucher() { }
        //ef
        public ICollection<Order> Order { get; set; }

        internal ValidationResult IsVoucherValid()
        {
            return new VoucherAppliedValidation().Validate(this);
        }
    }

    public class VoucherAppliedValidation : AbstractValidator<Voucher>
    {

        public VoucherAppliedValidation()
        {
            RuleFor(c => c.ExpireDate)
                .Must(ExpireDateIsHighThanCurrent)
                .WithMessage("This voucher is expired.");

            RuleFor(c => c.Active)
                .Equal(true)
                .WithMessage("This voucher is no longer available.");

            RuleFor(c => c.Used)
                .Equal(false)
                .WithMessage("This voucher has already been used.");

            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("This voucher is no longer available. ");
        }

        protected static bool ExpireDateIsHighThanCurrent(DateTime dataValidade)
        {
            return dataValidade >= DateTime.Now;
        }
    }
}