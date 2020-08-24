using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nutritions.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productgroepen",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductgroepNaam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productgroepen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producten",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductNaam = table.Column<string>(nullable: false),
                    ProductMassa = table.Column<double>(nullable: false),
                    Gevoelswaarde = table.Column<double>(nullable: false),
                    Gezondheidswaarde = table.Column<double>(nullable: false),
                    EnergieInKcal = table.Column<double>(nullable: false),
                    EnergieInKJoule = table.Column<double>(nullable: false),
                    Water = table.Column<double>(nullable: false),
                    Eiwit = table.Column<double>(nullable: false),
                    Vet = table.Column<double>(nullable: false),
                    VerzadigdVet = table.Column<double>(nullable: false),
                    EnkelvoudigVerzadigdVet = table.Column<double>(nullable: false),
                    MeervoudigVerzadigdVet = table.Column<double>(nullable: false),
                    Cholestrol = table.Column<double>(nullable: false),
                    Koolhydraten = table.Column<double>(nullable: false),
                    Suikers = table.Column<double>(nullable: false),
                    Voedingsvezels = table.Column<double>(nullable: false),
                    VitamineA = table.Column<double>(nullable: false),
                    VitamineB1 = table.Column<double>(nullable: false),
                    VitamineB2 = table.Column<double>(nullable: false),
                    VitamineB6 = table.Column<double>(nullable: false),
                    VitamineB11 = table.Column<double>(nullable: false),
                    VitamineB12 = table.Column<double>(nullable: false),
                    VitamineC = table.Column<double>(nullable: false),
                    VitamineD = table.Column<double>(nullable: false),
                    Natrium = table.Column<double>(nullable: false),
                    Kalium = table.Column<double>(nullable: false),
                    Calcium = table.Column<double>(nullable: false),
                    Fosfor = table.Column<double>(nullable: false),
                    Ijzer = table.Column<double>(nullable: false),
                    Magnesium = table.Column<double>(nullable: false),
                    Koper = table.Column<double>(nullable: false),
                    Zink = table.Column<double>(nullable: false),
                    ProductgroepId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producten_Productgroepen_ProductgroepId",
                        column: x => x.ProductgroepId,
                        principalTable: "Productgroepen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaaltijdProducten",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AantalInGram = table.Column<double>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    MaaltijdId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaaltijdProducten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaaltijdProducten_Producten_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Producten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maaltijden",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Beschrijving = table.Column<string>(maxLength: 255, nullable: false),
                    PersoonlijkDieetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maaltijden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naam = table.Column<string>(maxLength: 100, nullable: false),
                    Voornaam = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PersoonlijkDieetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersoonlijkDieeten",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Beschrijving = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoonlijkDieeten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersoonlijkDieeten_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maaltijden_PersoonlijkDieetId",
                table: "Maaltijden",
                column: "PersoonlijkDieetId");

            migrationBuilder.CreateIndex(
                name: "IX_MaaltijdProducten_MaaltijdId",
                table: "MaaltijdProducten",
                column: "MaaltijdId");

            migrationBuilder.CreateIndex(
                name: "IX_MaaltijdProducten_ProductId",
                table: "MaaltijdProducten",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PersoonlijkDieeten_UserId",
                table: "PersoonlijkDieeten",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Producten_ProductgroepId",
                table: "Producten",
                column: "ProductgroepId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersoonlijkDieetId",
                table: "Users",
                column: "PersoonlijkDieetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaaltijdProducten_Maaltijden_MaaltijdId",
                table: "MaaltijdProducten",
                column: "MaaltijdId",
                principalTable: "Maaltijden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maaltijden_PersoonlijkDieeten_PersoonlijkDieetId",
                table: "Maaltijden",
                column: "PersoonlijkDieetId",
                principalTable: "PersoonlijkDieeten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersoonlijkDieeten_PersoonlijkDieetId",
                table: "Users",
                column: "PersoonlijkDieetId",
                principalTable: "PersoonlijkDieeten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersoonlijkDieeten_PersoonlijkDieetId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MaaltijdProducten");

            migrationBuilder.DropTable(
                name: "Maaltijden");

            migrationBuilder.DropTable(
                name: "Producten");

            migrationBuilder.DropTable(
                name: "Productgroepen");

            migrationBuilder.DropTable(
                name: "PersoonlijkDieeten");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
