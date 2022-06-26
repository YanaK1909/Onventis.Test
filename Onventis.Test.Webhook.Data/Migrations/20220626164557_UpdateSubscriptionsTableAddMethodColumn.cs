using Microsoft.EntityFrameworkCore.Migrations;

namespace Onventis.Test.Webhook.Data.Migrations
{
    public partial class UpdateSubscriptionsTableAddMethodColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HttpMethod",
                table: "Subscription",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HttpMethod",
                table: "Subscription");
        }
    }
}
