using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.Task
{
    /// <inheritdoc />
    public partial class Tasks_Executors_Company_Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Executors_UserAssignedId",
                schema: "task",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                schema: "task",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                schema: "task",
                newName: "Executors_Company",
                newSchema: "task");

            migrationBuilder.RenameIndex(
                name: "IX_Company_UserAssignedId",
                schema: "task",
                table: "Executors_Company",
                newName: "IX_Executors_Company_UserAssignedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Executors_Company",
                schema: "task",
                table: "Executors_Company",
                columns: new[] { "OwnerId", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_Executors_Company_Executors_UserAssignedId",
                schema: "task",
                table: "Executors_Company",
                column: "UserAssignedId",
                principalSchema: "task",
                principalTable: "Executors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Executors_Company_Executors_UserAssignedId",
                schema: "task",
                table: "Executors_Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Executors_Company",
                schema: "task",
                table: "Executors_Company");

            migrationBuilder.RenameTable(
                name: "Executors_Company",
                schema: "task",
                newName: "Company",
                newSchema: "task");

            migrationBuilder.RenameIndex(
                name: "IX_Executors_Company_UserAssignedId",
                schema: "task",
                table: "Company",
                newName: "IX_Company_UserAssignedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                schema: "task",
                table: "Company",
                columns: new[] { "OwnerId", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Executors_UserAssignedId",
                schema: "task",
                table: "Company",
                column: "UserAssignedId",
                principalSchema: "task",
                principalTable: "Executors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
