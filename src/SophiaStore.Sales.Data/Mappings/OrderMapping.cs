using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Data.Mappings
{
    class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .HasDefaultValueSql("NEXT VALUE FOR MySequency");
            
            OneOrderToManyOrderItem(builder);

            builder.ToTable("Pedidos");
        }

        private static void OneOrderToManyOrderItem(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(c => c.OrderItems)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderId);
        }
    }
}