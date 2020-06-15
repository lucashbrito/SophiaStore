using System;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Catalog.Domain.Aggregate
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Image { get; private set; }
        public int StockQuantity { get; private set; }
        public Dimensions Dimensions { get; private set; }

        public Category Category { get; private set; }

        protected Product() { }

        public Product(Guid categoryId, string name, string description, bool active, decimal value, DateTime createdDate, string image, int stockQuantity, Dimensions dimensions)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            CreatedDate = createdDate;
            Image = image;
            StockQuantity = stockQuantity;
            Dimensions = dimensions;

            IsValid();
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void AlterCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void AddStock(int quantity)
        {
            StockQuantity += quantity;
        }

        public void DebitStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            StockQuantity -= quantity;
        }

        public bool HasAnyInStock(int quantity)
        {
            return StockQuantity >= quantity;
        }

        public void IsValid()
        {
            AssertionConcern.IsEmpty(Name, "Name Field can't be empty");
            AssertionConcern.IsEmpty(Description, "Description Field can't be empty");
            AssertionConcern.IsEquals(CategoryId, Guid.Empty, "CategoryId Field can't be empty");
            AssertionConcern.IsLessOrEquals(Value, 0, "Value Field can't be 0 or less");
            AssertionConcern.IsEmpty(Image, "Image Field can't be empty");
        }

    }
}
