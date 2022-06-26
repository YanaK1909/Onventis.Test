using EventBus.Base.Standard;

namespace Onventis.Test.Shared.Events
{
    public class InvoiceApprovedEvent : IntegrationEvent
    {
        public int InvoiceId { get; set; }
    }
}
