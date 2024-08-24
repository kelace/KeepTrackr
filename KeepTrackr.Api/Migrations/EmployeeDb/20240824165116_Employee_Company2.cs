using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.EmployeeDb
{
    /// <inheritdoc />
    public partial class Employee_Company2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Owners_OwnerId",
                schema: "emp",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Company_CompanyId",
                schema: "emp",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyId",
                schema: "emp",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                schema: "emp",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "emp",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Company",
                schema: "emp",
                newName: "Companies",
                newSchema: "emp");

            migrationBuilder.RenameIndex(
                name: "IX_Company_OwnerId",
                schema: "emp",
                table: "Companies",
                newName: "IX_Companies_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                schema: "emp",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employee_Company",
                schema: "emp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "emp",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Company_EmployeeId",
                schema: "emp",
                table: "Employee_Company",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Owners_OwnerId",
                schema: "emp",
                table: "Companies",
                column: "OwnerId",
                principalSchema: "emp",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Owners_OwnerId",
                schema: "emp",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Employee_Company",
                schema: "emp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                schema: "emp",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "emp",
                newName: "Company",
                newSchema: "emp");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OwnerId",
                schema: "emp",
                table: "Company",
                newName: "IX_Company_OwnerId");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "emp",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                schema: "emp",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                schema: "emp",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Owners_OwnerId",
                schema: "emp",
                table: "Company",
                column: "OwnerId",
                principalSchema: "emp",
                principalTable: "Owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Company_CompanyId",
                schema: "emp",
                table: "Employees",
                column: "CompanyId",
                principalSchema: "emp",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
