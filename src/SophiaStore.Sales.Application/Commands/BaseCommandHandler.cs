using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages;
using SophiaStore.Core.Messages.Notifications;

namespace SophiaStore.Sales.Application.Commands
{
    public class BaseCommandHandler
    {
        protected readonly IMediatorHandler MediatorHandler;

        public BaseCommandHandler(IMediatorHandler mediatorHandler)
        {
            MediatorHandler = mediatorHandler;
        }

        protected bool CheckCommand(Command request)
        {
            if (request.IsValid()) return true;

            foreach (var validationResultError in request.ValidationResult.Errors)
            {
                MediatorHandler.PostNotification(new DomainNotification(request.AggregateId.ToString(), validationResultError.ErrorMessage));
            }

            return false;
        }
    }
}
