using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SophiaStore.Catalog.Application.Services;
using SophiaStore.Catalog.Data;
using SophiaStore.Catalog.Data.Repository;
using SophiaStore.Catalog.Domain;
using SophiaStore.Catalog.Domain.Events;
using SophiaStore.Catalog.Domain.Services;
using SophiaStore.Core.Communication.Mediator;
using SophiaStore.Core.Messages.Notifications;
using SophiaStore.Sales.Application.Commands;
using SophiaStore.Sales.Application.Events;
using SophiaStore.Sales.Application.Queries;
using SophiaStore.Sales.Data;
using SophiaStore.Sales.Data.Repository;
using SophiaStore.Sales.Domain;

namespace SophiaStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            RegisterNotification(services);
            
            RegisterCatalog(services);
            
            RegisterSales(services);
        }

        private static void RegisterCatalog(IServiceCollection services)
        {
            services.AddScoped<CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IStockService, StockService>();

            services.AddScoped<INotificationHandler<ProductLowStockEvent>, ProductEventHandler>();
        }
         
        private static void RegisterNotification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        }

        private static void RegisterSales(IServiceCollection services)
        {
            services.AddScoped<SaleContext>();

            services.AddScoped<IRequestHandler<AddOrderItemCommand, bool>, AddOrderItemCommandHandler>();
            services.AddScoped<IRequestHandler<ApplyVoucherOrderCommand, bool>, ApplyVoucherOrderCommandHandler>();
            services.AddScoped<IRequestHandler<CancelProcessOrderReverseStockCommand, bool>, CancelProcessOrderReverseStockCommandHandler>();
            services.AddScoped<IRequestHandler<CancelProcessOrderCommand, bool>, CancelProcessOrderCommandHandler>();
            services.AddScoped<IRequestHandler<FinishOrderCommand, bool>, FinishOrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverOrderItemCommand, bool>, RemoverOrderItemCommandHandler>();
            services.AddScoped<IRequestHandler<StartOrderCommand, bool>, StartOrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderItemCommand, bool>, UpdateOrderItemCommandHandler>();


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderQueries, OrderQueries>();

            services.AddScoped<INotificationHandler<DraftOrderInitialEvent>, DraftOrderInitialEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderUpdatedEventHandler>();
            services.AddScoped<INotificationHandler<OrderFinishedEvent>, OrderFinishedEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderItemAddedEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemRemovedEvent>, OrderItemRemovedEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemUpdatedEvent>, OrderItemUpdatedEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderItemAddedEventHandler>();
            services.AddScoped<INotificationHandler<OrderVoucherAppliedEvent>, OrderVoucherAppliedEventHandler>();
        }
    }
}
