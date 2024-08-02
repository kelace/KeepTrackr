using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    /// <inheritdoc />
    public partial class Tasks_BoarsCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId_CompanyName",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CompanyId_CompanyOwnerId",
                schema: "task",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "Boards",
                schema: "task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardsCount = table.Column<int>(type: "int", nullable: false),
                    CompanyId_CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId_CompanyOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId_CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId_CompanyOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boards",
                schema: "task");

            migrationBuilder.DropTable(
                name: "Cards",
                schema: "task");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId_CompanyName",
                schema: "task",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId_CompanyOwnerId",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
