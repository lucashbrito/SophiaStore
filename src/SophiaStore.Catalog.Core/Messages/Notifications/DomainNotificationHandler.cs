using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SophiaStore.Core.Messages.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notification;

        public DomainNotificationHandler()
        {
            _notification = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notification.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notification;
        }

        public virtual bool HasNotification()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notification = new List<DomainNotification>();
        }
    }
}