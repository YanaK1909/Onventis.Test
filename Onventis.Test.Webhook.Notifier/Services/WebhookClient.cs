using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Onventis.Test.Shared.Events;
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
            _logger.LogInformation($"Call the following webhook method:\r\n" +
                $"URL: {notifyEvent.SubscriptionUrl}\r\n" +
                $"METHOD: {notifyEvent.HttpMethod}\r\n" +
                $"BODY: {JsonConvert.SerializeObject(notifyEvent.Body)}");

            return Task.CompletedTask;
        }
    }
}
