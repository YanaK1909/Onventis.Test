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

        public Task InvoiceApprovedNotifySubscribers(InvoiceApprovedEvent invoiceApprovedEvent)
        {
            var body = new { InvoiceId = invoiceApprovedEvent.InvoiceId };

            return NotifySubscribers(nameof(InvoiceApprovedEvent), body);
        }

        private async Task NotifySubscribers(string eventName, object body = null)
        {
            var subscribersList = await _subscriptionRepository.ListAsync(x => x.EventName == eventName);

            foreach (var subscriber in subscribersList)
            {
                var notifyEvent = new NotifyWebhookSubscriberEvent
                {
                    Body = body,
                    SubscriptionUrl = subscriber.SubscriptionUrl
                };

                _eventBus.Publish(notifyEvent);
            }
        }
    }
}
