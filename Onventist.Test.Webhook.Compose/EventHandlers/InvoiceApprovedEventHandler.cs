using EventBus.Base.Standard;
using Microsoft.Extensions.Logging;
using Onventis.Test.Shared.Events;
using System.Threading.Tasks;

namespace Onventist.Test.Webhook.Compose.EventHandlers
{
    public class InvoiceApprovedEventHandler : IIntegrationEventHandler<InvoiceApprovedEvent>
    {
        private readonly ILogger<InvoiceApprovedEventHandler> _logger;
        public InvoiceApprovedEventHandler(ILogger<InvoiceApprovedEventHandler> logger)
        {
            this._logger = logger;
        }

        public Task Handle(InvoiceApprovedEvent @event)
        {
            _logger.LogInformation($"Handle invoice approved event for invoice with ID {@event.InvoiceId}");
            return Task.CompletedTask;
            //Handle the ItemCreatedIntegrationEvent event here.
        }
    }
}
