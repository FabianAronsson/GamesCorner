using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EventUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "374a8e10-1f7c-40d9-9324-541b3dada8ef", null, "Administrator", "ADMINISTRATOR" },
                    { "c6fd9b86-a45f-4afd-8b30-23300ca32053", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "374a8e10-1f7c-40d9-9324-541b3dada8ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6fd9b86-a45f-4afd-8b30-23300ca32053");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c46fde1-08bd-432d-9e1e-534e813de780", null, "Customer", "CUSTOMER" },
                    { "d14d183b-90cb-4f72-b572-3d1eee5e90f0", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
