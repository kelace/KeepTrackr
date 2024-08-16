using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    /// <inheritdoc />
    public partial class Tasks_Label : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelLineItem",
                schema: "task");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                schema: "task",
                table: "Label",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CardId1",
                schema: "task",
                table: "Label",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "task",
                table: "Label",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Label_CardId",
                schema: "task",
                table: "Label",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Label_CardId1",
                schema: "task",
                table: "Label",
                column: "CardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Cards_CardId",
                schema: "task",
                table: "Label",
                column: "CardId",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Cards_CardId1",
                schema: "task",
                table: "Label",
                column: "CardId1",
                principalSchema: "task",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Label_Cards_CardId",
                schema: "task",
                table: "Label");

            migrationBuilder.DropForeignKey(
                name: "FK_Label_Cards_CardId1",
                schema: "task",
                table: "Label");

            migrationBuilder.DropIndex(
                name: "IX_Label_CardId",
                schema: "task",
                table: "Label");

            migrationBuilder.DropIndex(
                name: "IX_Label_CardId1",
                schema: "task",
                table: "Label");

            migrationBuilder.DropColumn(
                name: "CardId",
                schema: "task",
                table: "Label");

            migrationBuilder.DropColumn(
                name: "CardId1",
                schema: "task",
                table: "Label");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "task",
                table: "Label");

            migrationBuilder.CreateTable(
                name: "LabelLineItem",
                schema: "task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelLineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelLineItem_Label_LabelId",
                        column: x => x.LabelId,
                        principalSchema: "task",
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelLineItem_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "task",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelLineItem_LabelId",
                schema: "task",
                table: "LabelLineItem",
                column: "LabelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabelLineItem_TaskId",
                schema: "task",
                table: "LabelLineItem",
                column: "TaskId");
        }
    }
}
