using System.Threading.Tasks;
using MediatR;
using SophiaStore.Core.Messages;
using SophiaStore.Core.Messages.Notifications;

namespace SophiaStore.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;


        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PostEvent<T>(T pEvent) where T : Event
        {
            await _mediator.Publish(pEvent);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PostNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }
    }
}
