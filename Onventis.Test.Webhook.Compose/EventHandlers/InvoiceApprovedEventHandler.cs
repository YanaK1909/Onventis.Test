using EventBus.Base.Standard;
using Onventis.Test.Shared.Events;
using Onventist.Test.Webhook.Compose.Services;
using System.Threading.Tasks;

namespace Onventist.Test.Webhook.Compose.EventHandlers
{
    public class InvoiceApprovedEventHandler : IIntegrationEventHandler<InvoiceApprovedEvent>
    {
        private readonly IWebhookService _webhookService;

        public InvoiceApprovedEventHandler(IWebhookService webhookService)
        {
            this._webhookService = webhookService;
        }

        public Task Handle(InvoiceApprovedEvent @event)
        {
            return _webhookService.InvoiceApprovedNotifySubscribers(@event);
        }
    }
}
