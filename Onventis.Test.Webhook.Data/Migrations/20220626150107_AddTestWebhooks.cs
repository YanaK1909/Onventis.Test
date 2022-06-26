using Microsoft.EntityFrameworkCore.Migrations;
using Onventis.Test.Webhook.Data.Entities;

namespace Onventis.Test.Webhook.Data.Migrations
{
    public partial class AddTestWebhooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: nameof(Subscription),
                columns: new[] { nameof(Subscription.Id), nameof(Subscription.EventName), nameof(Subscription.SubscriptionUrl) },
                values: new object[] { 1, "InvoiceApprovedEvent", "http://some-url-1.com/invoice/approved/{0}" });

            migrationBuilder.InsertData(
                table: nameof(Subscription),
                columns: new[] { nameof(Subscription.Id), nameof(Subscription.EventName), nameof(Subscription.SubscriptionUrl) },
                values: new object[] { 2, "InvoiceApprovedEvent", "http://some-url-2.com/invoice/approved/{0}" });

            migrationBuilder.InsertData(
                table: nameof(Subscription),
                columns: new[] { nameof(Subscription.Id), nameof(Subscription.EventName), nameof(Subscription.SubscriptionUrl) },
                values: new object[] { 3, "InvoiceCanceledEvent", "http://some-url-1.com/invoice/canceled/{0}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
