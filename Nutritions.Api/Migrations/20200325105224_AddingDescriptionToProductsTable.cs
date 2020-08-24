using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutritions.Api.Migrations
{
    public partial class AddingDescriptionToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductMassa",
                table: "Producten");

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Producten",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProductPortie",
                table: "Producten",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "ProductPortie",
                table: "Producten");

            migrationBuilder.AddColumn<double>(
                name: "ProductMassa",
                table: "Producten",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
