using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatepostcodelength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61053990-df54-4990-9a74-bac19d00ab74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85892559-b6c5-445d-890b-3d829a564c6c");

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b844409-6260-47a8-896d-c94b8867591e", null, "Customer", "CUSTOMER" },
                    { "8aff94d2-9a56-4007-8e6d-50de00bce288", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b844409-6260-47a8-896d-c94b8867591e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aff94d2-9a56-4007-8e6d-50de00bce288");

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "AspNetUsers",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61053990-df54-4990-9a74-bac19d00ab74", null, "Customer", "CUSTOMER" },
                    { "85892559-b6c5-445d-890b-3d829a564c6c", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
