using System.Threading.Tasks;
using SophiaStore.Core.Messages;
using SophiaStore.Core.Messages.Notifications;

namespace SophiaStore.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PostEvent<T>(T pEvent) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PostNotification<T>(T command) where T : DomainNotification;
    }
}