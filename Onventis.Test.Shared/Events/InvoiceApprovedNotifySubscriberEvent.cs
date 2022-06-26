using EventBus.Base.Standard;

namespace Onventis.Test.Shared.Events
{
    public class InvoiceApprovedNotifySubscriberEvent : IntegrationEvent
    {
        public int InvoiceId { get; set; }
        public string SubscriptionUrl { get; set; }
    }
}
