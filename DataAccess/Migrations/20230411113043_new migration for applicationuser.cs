using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newmigrationforapplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "458d9f95-3cc7-447f-821c-c95a7b580edd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8677555-7e1e-4f76-8f26-cb9b3248506a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61053990-df54-4990-9a74-bac19d00ab74", null, "Customer", "CUSTOMER" },
                    { "85892559-b6c5-445d-890b-3d829a564c6c", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61053990-df54-4990-9a74-bac19d00ab74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85892559-b6c5-445d-890b-3d829a564c6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "458d9f95-3cc7-447f-821c-c95a7b580edd", null, "Administrator", "ADMINISTRATOR" },
                    { "d8677555-7e1e-4f76-8f26-cb9b3248506a", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
