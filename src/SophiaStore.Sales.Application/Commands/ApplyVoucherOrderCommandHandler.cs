using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages.Notifications;
using SophiaStore.Sales.Application.Events;
using SophiaStore.Sales.Domain;

namespace SophiaStore.Sales.Application.Commands
{
    public class ApplyVoucherOrderCommandHandler : BaseCommandHandler, IRequestHandler<ApplyVoucherOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public ApplyVoucherOrderCommandHandler(IMediatorHandler mediatorHandler, IOrderRepository orderRepository)
            : base(mediatorHandler)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(ApplyVoucherOrderCommand request, CancellationToken cancellationToken)
        {
            if (!CheckCommand(request)) return false;

            var order = await _orderRepository.GetDraftOrderByClientId(request.ClientId);

            if (order == null)
            {
                await MediatorHandler.PostNotification(new DomainNotification("order", "Order not found!"));
                return false;
            }

            var voucher = await _orderRepository.GetVoucherByCode(request.VoucherCode);

            if (voucher == null)
            {
                await MediatorHandler.PostNotification(new DomainNotification("order", "Voucher not found!"));
                return false;
            }

            var voucherApplied = order.ApplyVoucher(voucher);
            if (!voucherApplied.IsValid)
            {
                foreach (var error in voucherApplied.Errors)
                {
                    await MediatorHandler.PostNotification(new DomainNotification(error.ErrorCode, error.ErrorMessage));
                }

                return false;
            }

            order.AddEvent(new OrderUpdatedEvent(order.ClientId, order.Id, order.TotalValue));
            order.AddEvent(new OrderVoucherAppliedEvent(request.ClientId, order.Id, voucher.Id));

            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
