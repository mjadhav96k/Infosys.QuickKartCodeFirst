using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infosys.CodeFirstCore.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureEntitiesUsingFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.AddUniqueConstraint(
                name: "uq_ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.AddUniqueConstraint(
                name: "uq_CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "fk_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_CategoryId",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "uq_ProductName",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "uq_CategoryName",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
