using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages.Notifications;
using SophiaStore.Sales.Application.Events;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Application.Commands
{
    public class UpdateOrderItemCommandHandler : BaseCommandHandler, IRequestHandler<UpdateOrderItemCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderItemCommandHandler(IOrderRepository orderRepository, IMediatorHandler mediatorHandler)
            :base(mediatorHandler)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!CheckCommand(request)) return false;

            var order = await _orderRepository.GetDraftOrderByClientId(request.ClientId);

            if (order == null)
            {
                await MediatorHandler.PostNotification(new DomainNotification("pedido", "Pedido não encontrado!"));
                return false;
            }

            var pedidoItem = await _orderRepository.GetOrderItemByOrder(order.Id, request.ProductId);

            if (!order.OrderItemExistent(pedidoItem))
            {
                await MediatorHandler.PostNotification(new DomainNotification("pedido", "Item do pedido não encontrado!"));
                return false;
            }

            order.UpdateQuantity(pedidoItem, request.Quantity);

            order.AddEvent(new OrderUpdatedEvent(order.ClientId, order.Id, order.TotalValue));
            order.AddEvent(new  OrderItemUpdatedEvent(request.ClientId, order.Id, request.ProductId, request.Quantity));

            _orderRepository.UpdateOrderItem(pedidoItem);
            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
