using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Subscription
{
    /// <inheritdoc />
    public partial class Subscription_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                column: "Type",
                values: new object[]
                {
                    "Normal",
                    "Premium",
                    "Standart"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Type",
                keyValue: "Normal");

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Type",
                keyValue: "Premium");

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Type",
                keyValue: "Standart");
        }
    }
}
