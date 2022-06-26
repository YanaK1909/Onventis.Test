using Onventis.Test.Shared.Events;
using System.Threading.Tasks;

namespace Onventist.Test.Webhook.Compose.Services
{
    public interface IWebhookService
    {
        Task InvoiceApprovedNotifySubscribers(InvoiceApprovedEvent invoiceApprovedEvent);
    }
}
