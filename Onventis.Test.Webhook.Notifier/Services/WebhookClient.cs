using Microsoft.Extensions.Logging;
using Onventis.Test.Shared.Events;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onventis.Test.Webhook.Notifier.Services
{
    public class WebhookClient : IWebhookClient
    {
        private readonly ILogger<WebhookClient> _logger;

        public WebhookClient(ILogger<WebhookClient> logger)
        {
            _logger = logger;
        }

        public Task NotifySubscriber(NotifyWebhookSubscriberEvent notifyEvent)
        {
            // TODO: create Http Client with URl and specified HTTP method. Add body if exists
            _logger.LogInformation($"Call the following webhook method:/n" +
                $"URL: {notifyEvent.SubscriptionUrl}" +
                $"METHOD: {notifyEvent.HttpMethod}" +
                $"BODY: {JsonSerializer.Serialize(notifyEvent.Body)}");

            return Task.CompletedTask;
        }
    }
}
