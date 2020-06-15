using System;
using System.Threading.Tasks;
using SophiaStore.Catalog.Domain.Events;
using SophiaStore.Core.Communication.Mediator;

namespace SophiaStore.Catalog.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _memoryBus;

        public StockService(IProductRepository productRepository, IMediatorHandler memoryBus)
        {
            _productRepository = productRepository;
            _memoryBus = memoryBus;
        }

        public async Task<bool> Debit(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null) return false;

            if (!product.HasAnyInStock(quantity)) return false;

            product.DebitStock(quantity);

            if (product.StockQuantity < 2)
            {
                await _memoryBus.PostEvent(new ProductLowStockEvent(product.Id, product.StockQuantity));
            }

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Replace(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null) return false;

            if (!product.HasAnyInStock(quantity)) return false;

            product.AddStock(quantity);

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
