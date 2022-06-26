using EventBus.Base.Standard;

namespace Onventis.Test.Shared.Events
{
    public class NotifyWebhookSubscriberEvent : IntegrationEvent
    {
        public object Body { get; set; }
        public string SubscriptionUrl { get; set; }
        public string HttpMethod { get; set; }
    }
}
