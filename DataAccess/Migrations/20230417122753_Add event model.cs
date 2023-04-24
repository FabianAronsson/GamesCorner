using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addeventmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b844409-6260-47a8-896d-c94b8867591e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aff94d2-9a56-4007-8e6d-50de00bce288");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c46fde1-08bd-432d-9e1e-534e813de780", null, "Customer", "CUSTOMER" },
                    { "d14d183b-90cb-4f72-b572-3d1eee5e90f0", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c46fde1-08bd-432d-9e1e-534e813de780");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d14d183b-90cb-4f72-b572-3d1eee5e90f0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b844409-6260-47a8-896d-c94b8867591e", null, "Customer", "CUSTOMER" },
                    { "8aff94d2-9a56-4007-8e6d-50de00bce288", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
