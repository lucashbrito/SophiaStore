﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages.Notifications;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Application.Commands
{
    public class CancelProcessOrderCommandHandler : BaseCommandHandler, IRequestHandler<CancelProcessOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public CancelProcessOrderCommandHandler(IOrderRepository orderRepository, IMediatorHandler mediatorHandler)
            :base(mediatorHandler)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(CancelProcessOrderCommand request, CancellationToken cancellationToken)
        {
            if (!CheckCommand(request)) return false;

            var order = await _orderRepository.GetOrderById(request.ClientId);

            if (order == null)
            {
                await MediatorHandler.PostNotification(new DomainNotification("pedido", "Pedido não encontrado!"));
                return false;
            }

            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
