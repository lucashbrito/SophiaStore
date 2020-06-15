using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Data.Mappings
{
    class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.NameProduct)
                .IsRequired()
                .HasColumnType("varchar(250)");

            OneOrderToManyPayment(builder);

            builder.ToTable("OrderItem");
        }

        private static void OneOrderToManyPayment(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(c => c.Order)
                .WithMany(c => c.OrderItems);
        }
    }
}