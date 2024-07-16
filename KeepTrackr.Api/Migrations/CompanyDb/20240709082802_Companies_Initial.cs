using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeepTrackr.Api.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class Companies_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "companies");

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTypes",
                schema: "companies",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllowedCompaniesCount = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "companies",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Company_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "companies",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowedCompaniesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "companies",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "SubscriptionTypes",
                columns: new[] { "Type", "AllowedCompaniesCount", "Id" },
                values: new object[,]
                {
                    { "Gold", 50, new Guid("00000000-0000-0000-0000-000000000000") },
                    { "Normal", 10, new Guid("00000000-0000-0000-0000-000000000000") },
                    { "Silver", 25, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_OwnerId",
                schema: "companies",
                table: "Company",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_OwnerId",
                schema: "companies",
                table: "Subscription",
                column: "OwnerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "SubscriptionTypes",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "Owners",
                schema: "companies");
        }
    }
}
