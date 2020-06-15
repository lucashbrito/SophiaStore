using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Data.Mappings
{
    class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Code)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            OneVoucherToManyOrders(builder);

            builder.ToTable("Vouchers");
        }

        private static void OneVoucherToManyOrders(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasMany(c => c.Order)
                .WithOne(c => c.Voucher)
                .HasForeignKey(c => c.VoucherId);
        }
    }
}