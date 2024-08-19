using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    /// <inheritdoc />
    public partial class Tasks_Cards_Tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Executors_AssignedTo",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedTo",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                schema: "task",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                schema: "task",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CardId",
                schema: "task",
                table: "Tasks",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cards_CardId",
                schema: "task",
                table: "Tasks",
                column: "CardId",
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

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CardId",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CardId",
                schema: "task",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Completed",
                schema: "task",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedTo",
                schema: "task",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedTo",
                schema: "task",
                table: "Tasks",
                column: "AssignedTo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Executors_AssignedTo",
                schema: "task",
                table: "Tasks",
                column: "AssignedTo",
                principalSchema: "task",
                principalTable: "Executors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
