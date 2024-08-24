using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    /// <inheritdoc />
    public partial class Tasks_Task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Label_Cards_CardId1",
                schema: "task",
                table: "Label");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cards_CardId1",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CardId1",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Label_CardId1",
                schema: "task",
                table: "Label");

            migrationBuilder.DropColumn(
                name: "CardId1",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CardId1",
                schema: "task",
                table: "Label");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CardId1",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CardId1",
                schema: "task",
                table: "Label",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CardId1",
                schema: "task",
                table: "Tasks",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_Label_CardId1",
                schema: "task",
                table: "Label",
                column: "CardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Cards_CardId1",
                schema: "task",
                table: "Label",
                column: "CardId1",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cards_CardId1",
                schema: "task",
                table: "Tasks",
                column: "CardId1",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id");
        }
    }
}
