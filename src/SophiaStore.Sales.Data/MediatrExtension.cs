using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Sales.Data
{
    public static class MediatrExtension
    {
        public static async Task PostEvent(this IMediatorHandler mediator, SaleContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PostEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
