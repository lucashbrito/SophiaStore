using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages;
using SophiaStore.Core.Messages.Notifications;
using SophiaStore.Sales.Application.Events;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Application.Commands
{
    public class OrderCommandHandler : IRequestHandler<AddOrderItemCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler _mediatorHandler;
        public OrderCommandHandler(IOrderRepository orderRepository, MediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!CheckCommand(request)) return false;

            var order = await _orderRepository.GetDraftOrderByClientId(request.ClientId);
            var orderItem = new OrderItem(request.ProductId, request.Name, request.Quantity, request.Value);

            if (order == null)
            {
                order = Order.OrderFactory.NewOrderDraft(request.ClientId);
                order.AddOrderItem(orderItem);

                _orderRepository.Add(order);
                order.AddEvent(new InitialDraftOrderEvent(request.ClientId, request.ProductId));
            }
            else
            {
                var existentOrderItem = order.OrdemItemExsitent(orderItem);
                order.AddOrderItem(orderItem);

                if (existentOrderItem)
                {
                    _orderRepository.UpdateOrderItem(order.OrderItems.FirstOrDefault(p => p.ProductId == orderItem.ProductId));
                }
                else
                {
                    _orderRepository.AddOrderItem(orderItem);
                }

                order.AddEvent(new UpdateOrderEvent(order.ClientId, order.Id, order.TotalValue));
            }

            order.AddEvent(new AddOrderItemEvent(order.ClientId, order.Id, request.ProductId, request.Value, request.Quantity));
            return await _orderRepository.UnitOfWork.Commit();
        }

        private bool CheckCommand(Command request)
        {
            if (request.IsValid()) return true;

            foreach (var validationResultError in request.ValidationResult.Errors)
            {
                _mediatorHandler.PostNotification(new DomainNotification(request.AggregateId.ToString(), validationResultError.ErrorMessage));
            }

            return false;
        }
    }
}
