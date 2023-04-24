using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateappcontext : Migration
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
                    { "06be3b31-05a0-4f2f-8cdd-1a62b075e160", null, "Administrator", "ADMINISTRATOR" },
                    { "d85b858a-6d53-4b1e-bc6c-4969060dd4bc", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06be3b31-05a0-4f2f-8cdd-1a62b075e160");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d85b858a-6d53-4b1e-bc6c-4969060dd4bc");

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
