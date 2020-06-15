using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SophiaStore.Catalog.Domain.Aggregate;

namespace SophiaStore.Catalog.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250");

            builder.Property(c => c.Code)
                .HasColumnType("varchar(250");

            OneCategoryToManyProduct(builder);

            builder.ToTable("Category");
        }

        private static void OneCategoryToManyProduct(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Product)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}