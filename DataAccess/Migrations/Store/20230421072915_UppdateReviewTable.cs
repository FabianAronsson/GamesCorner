using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.Store
{
    /// <inheritdoc />
    public partial class UppdateReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductModelId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductModelId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Reviews",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductModelId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductModelId",
                table: "Reviews",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductModelId",
                table: "Reviews",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
