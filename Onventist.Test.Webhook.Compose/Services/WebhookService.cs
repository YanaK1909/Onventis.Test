using EventBus.Base.Standard;
using Microsoft.Extensions.Logging;
using Onventis.Test.Shared.Events;
using Onventis.Test.Webhook.Data.Entities;
using Onventis.Test.Webhook.Data.Repositories;
using System.Threading.Tasks;

namespace Onventist.Test.Webhook.Compose.Services
{
    public class WebhookService : IWebhookService
    {
        private readonly ILogger<WebhookService> _logger;
        private readonly IRepository<Subscription> _subscriptionRepository;
        private readonly IEventBus _eventBus;

        public WebhookService(
            ILogger<WebhookService> logger,
            IRepository<Subscription> subscriptionRepository,
            IEventBus eventBus)
        {
            _logger = logger;
            _subscriptionRepository = subscriptionRepository;
            _eventBus = eventBus;
        }

        public async Task InvoiceApprovedNotifySubscribers(InvoiceApprovedEvent invoiceApprovedEvent)
        {
            var subscribersList = await _subscriptionRepository.ListAsync(x => x.EventName == nameof(InvoiceApprovedEvent));

            foreach(var subscriber in subscribersList)
            {
                var notifyEvent = new InvoiceApprovedNotifySubscriberEvent
                {
                    InvoiceId = invoiceApprovedEvent.InvoiceId,
                    SubscriptionUrl = subscriber.SubscriptionUrl
                };

                _eventBus.Publish(notifyEvent);
            }
        }
    }
}
