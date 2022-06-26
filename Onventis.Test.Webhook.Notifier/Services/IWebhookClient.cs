using Onventis.Test.Shared.Events;
using System.Threading.Tasks;

namespace Onventis.Test.Webhook.Notifier.Services
{
    public interface IWebhookClient
    {
        Task NotifySubscriber(NotifyWebhookSubscriberEvent notifyEvent);
    }
}
