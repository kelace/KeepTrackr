using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    /// <inheritdoc />
    public partial class Tasks_Card_Task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cards_CardId",
                schema: "task",
                table: "Tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "CardId",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CardId1",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CardId1",
                schema: "task",
                table: "Tasks",
                column: "CardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cards_CardId",
                schema: "task",
                table: "Tasks",
                column: "CardId",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cards_CardId1",
                schema: "task",
                table: "Tasks",
                column: "CardId1",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cards_CardId",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cards_CardId1",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CardId1",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CardId1",
                schema: "task",
                table: "Tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "CardId",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cards_CardId",
                schema: "task",
                table: "Tasks",
                column: "CardId",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id");
        }
    }
}
