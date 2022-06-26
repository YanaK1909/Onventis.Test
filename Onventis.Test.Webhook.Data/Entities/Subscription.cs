namespace Onventis.Test.Webhook.Data.Entities
{
    public class Subscription
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string SubscriptionUrl { get; set; }
    }
}
