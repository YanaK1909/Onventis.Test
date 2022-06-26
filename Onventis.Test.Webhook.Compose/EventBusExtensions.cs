using EventBus.Base.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Onventis.Test.Shared.Events;
using Onventist.Test.Webhook.Compose.EventHandlers;
using System.Collections.Generic;

namespace Onventist.Test.Webhook.Compose
{
    public static class EventBusExtensions
    {
        public static IEnumerable<IIntegrationEventHandler> GetHandlers(IServiceCollection services)
        {
            services.AddScoped<InvoiceApprovedEventHandler>();

            var serviceProvider = services.BuildServiceProvider();

            return new List<IIntegrationEventHandler>
            {
                serviceProvider.GetService<InvoiceApprovedEventHandler>()
            };
        }

        public static IApplicationBuilder SubscribeToEvents(this IApplicationBuilder app)
        {
            var eventBus = (IEventBus)app.ApplicationServices.GetService(typeof(IEventBus));

            eventBus.Subscribe<InvoiceApprovedEvent, InvoiceApprovedEventHandler>();

            return app;
        }
    }
}
