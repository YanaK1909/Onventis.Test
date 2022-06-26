using EventBus.Base.Standard;
using Onventis.Test.Shared.Events;
using Onventis.Test.Webhook.Notifier.Services;
using System.Threading.Tasks;

namespace Onventis.Test.Webhook.Notifier.EventHandlers
{
    public class NotifyWebhookSubscriberEventHandler : IIntegrationEventHandler<NotifyWebhookSubscriberEvent>
    {
        private readonly IWebhookClient _client;

        public NotifyWebhookSubscriberEventHandler(IWebhookClient client)
        {
            _client = client;
        }

        public Task Handle(NotifyWebhookSubscriberEvent @event)
        {
            return _client.NotifySubscriber(@event);
        }
    }
}
