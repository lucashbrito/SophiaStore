using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SophiaStore.Catalog.Domain.Events
{
    public class ProductEventHandler : INotificationHandler<ProductLowStockEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductLowStockEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(notification.AggregateId);
        }
    }
}
