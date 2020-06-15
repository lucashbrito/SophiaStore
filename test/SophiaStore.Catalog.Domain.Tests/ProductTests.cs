using System;
using SophiaStore.Catalog.Domain.Aggregate;
using SophiaStore.Core.DomainObjects;
using Xunit;

namespace SophiaStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Should_Create_Product()
        {
            var guid = Guid.NewGuid();
            var createdProduct = DateTime.Now;
            var product = new Product(guid, "Name", "Description", false, 100, createdProduct, "Image", 2,
                new Dimensions(12, 12, 12));

            Assert.Equal(guid, product.CategoryId);
            Assert.Equal("Name", product.Name);
            Assert.Equal("Description", product.Description);
            Assert.False(product.Active);
            Assert.Equal(100, product.Value);
            Assert.Equal(createdProduct, product.CreatedDate);
            Assert.Equal("Image", product.Image);
            Assert.Equal(12, product.Dimensions.Depth);
            Assert.Equal(12, product.Dimensions.Height);
            Assert.Equal(12, product.Dimensions.Width);
        }

        [Fact]
        public void Should_ThrowExceptions_WhenNameIsInvalid()
        {
            var ex = Assert.Throws<DomainException>(() => new Product(
                Guid.NewGuid(), string.Empty, "Description", false, 100, DateTime.Now, "image", 2,
                new Dimensions(12, 12, 12))
            );

            Assert.Equal("Name Field can't be empty", ex.Message);
        }

        [Fact]
        public void Should_ThrowExceptions_WhenCategoryIdIsInvalid()
        {
            var ex = Assert.Throws<DomainException>(() => new Product(
                Guid.Empty, "Name", "Description", false, 100, DateTime.Now, "image", 2,
                new Dimensions(12, 12, 12))
            );

            Assert.Equal("CategoryId Field can't be empty", ex.Message);
        }

        [Fact]
        public void Should_ThrowExceptions_WhenDescriptionIsInvalid()
        {
            var ex = Assert.Throws<DomainException>(() => new Product(
                Guid.NewGuid(), "Name", string.Empty, false, 100, DateTime.Now, "image", 2,
                new Dimensions(12, 12, 12))
            );

            Assert.Equal("Description Field can't be empty", ex.Message);
        }

        [Fact]
        public void Should_ThrowExceptions_WhenImageIsInvalid()
        {
            var ex = Assert.Throws<DomainException>(() => new Product(
                Guid.NewGuid(), "Name", "Descrption", false, 100, DateTime.Now, string.Empty, 2,
                new Dimensions(12, 12, 12))
            );

            Assert.Equal("Image Field can't be empty", ex.Message);
        }

        [Fact]
        public void Should_ThrowExceptions_WhenValueIsInvalid()
        {
            var ex = Assert.Throws<DomainException>(() => new Product(
                Guid.NewGuid(), "Name", "Description", false, 0, DateTime.Now, "image", 2,
                new Dimensions(12, 12, 12))
            );

            Assert.Equal("Value Field can't be 0 or less", ex.Message);
        }
    }
}
