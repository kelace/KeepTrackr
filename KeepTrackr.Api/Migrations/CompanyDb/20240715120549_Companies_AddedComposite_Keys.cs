using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepTrackr.Api.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class Companies_AddedComposite_Keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                schema: "companies",
                table: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                schema: "companies",
                table: "Company",
                columns: new[] { "Name", "OwnerId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                schema: "companies",
                table: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                schema: "companies",
                table: "Company",
                column: "Name");
        }
    }
}
