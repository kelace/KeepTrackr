using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.EmployeeDb
{
    /// <inheritdoc />
    public partial class Employee_Company3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "emp",
                table: "Employee_Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                schema: "emp",
                table: "Employee_Company",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "emp",
                table: "Employee_Company");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "emp",
                table: "Employee_Company");
        }
    }
}
