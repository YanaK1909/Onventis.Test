namespace Onventis.Test.Webhook.Data.Entities
{
    //TODO: Change entities structure to:
    //      WebhookType: EventName, HttpMethod, params, etc
    //      Subscription: WebhookTypeId, SubscriptionUrl
    public class Subscription
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string SubscriptionUrl { get; set; }

        public string HttpMethod { get; set; }      // TODO: move to enum (Get, Post, etc)
    }
}
