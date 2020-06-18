using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages.Notifications;
using SophiaStore.Sales.Application.Events;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Application.Commands
{
    public class RemoverOrderItemCommandHandler : BaseCommandHandler, IRequestHandler<RemoverOrderItemCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoverOrderItemCommandHandler(IMediatorHandler mediatorHandler, IOrderRepository orderRepository)
            : base(mediatorHandler)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(RemoverOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!CheckCommand(request)) return false;

            var order = await _orderRepository.GetDraftOrderByClientId(request.ClientId);

            if (order == null)
            {
                await MediatorHandler.PostNotification(new DomainNotification("pedido", "Order not found!"));
                return false;
            }

            var orderItem = await _orderRepository.GetOrderItemByOrder(order.Id, request.ProductId);

            if (orderItem != null && !order.OrderItemExistent(orderItem))
            {
                await MediatorHandler.PostNotification(new DomainNotification("order", "Order Item not found!"));
                return false;
            }

            order.RemoveOrderItem(orderItem);
            order.AddEvent(new OrderUpdatedEvent(order.ClientId, order.Id, order.TotalValue));
            order.AddEvent(new OrderItemRemovedEvent(request.ClientId, order.Id, request.ProductId));

            _orderRepository.RemoveOrderItem(orderItem);
            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
