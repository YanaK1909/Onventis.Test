using EventBus.Base.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Onventis.Test.Shared.Events;
using Onventis.Test.Webhook.Notifier.EventHandlers;
using System.Collections.Generic;

namespace Onventis.Test.Webhook.Notifier
{
    public static class EventBusExtensions
    {
        public static IEnumerable<IIntegrationEventHandler> GetHandlers(IServiceCollection services)
        {
            services.AddScoped<NotifyWebhookSubscriberEventHandler>();

            var serviceProvider = services.BuildServiceProvider();

            return new List<IIntegrationEventHandler>
            {
                serviceProvider.GetService<NotifyWebhookSubscriberEventHandler>()
            };
        }

        public static IApplicationBuilder SubscribeToEvents(this IApplicationBuilder app)
        {
            var eventBus = (IEventBus)app.ApplicationServices.GetService(typeof(IEventBus));

            eventBus.Subscribe<NotifyWebhookSubscriberEvent, NotifyWebhookSubscriberEventHandler>();

            return app;
        }
    }
}
