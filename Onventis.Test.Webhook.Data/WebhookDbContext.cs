using Microsoft.EntityFrameworkCore;
using Onventis.Test.Webhook.Data.Entities;

namespace Onventis.Test.Webhook.Data
{
    public class WebhookDbContext : DbContext
    {
        public WebhookDbContext()
        {
        }

        public WebhookDbContext(DbContextOptions<WebhookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subscription> Subscription { get; set; }
    }
}
