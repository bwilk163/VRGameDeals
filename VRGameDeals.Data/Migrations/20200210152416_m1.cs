using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VRGameDeals.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PlatformGame",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    PlatformId = table.Column<Guid>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformGame", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PlatformGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformGame_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Site = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PlatformGameId = table.Column<Guid>(nullable: false),
                    GameGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Discounts_Games_GameGuid",
                        column: x => x.GameGuid,
                        principalTable: "Games",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discounts_PlatformGame_PlatformGameId",
                        column: x => x.PlatformGameId,
                        principalTable: "PlatformGame",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Guid", "Description", "Name" },
                values: new object[] { new Guid("26f2a34c-7f9f-40e6-aeca-6a875ace5be9"), "FPS Shooter", "Pavlov" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Guid", "Description", "Name" },
                values: new object[] { new Guid("c4149c8f-b816-4c75-ae8d-94c9b7d18c9b"), "Mobile", "Oculus Quest" });

            migrationBuilder.InsertData(
                table: "PlatformGame",
                columns: new[] { "Guid", "GameId", "PlatformId", "Price", "ReleaseDate" },
                values: new object[] { new Guid("12386a1d-6cb1-4502-bce4-f14afba68264"), new Guid("26f2a34c-7f9f-40e6-aeca-6a875ace5be9"), new Guid("c4149c8f-b816-4c75-ae8d-94c9b7d18c9b"), 99m, new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_GameGuid",
                table: "Discounts",
                column: "GameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_PlatformGameId",
                table: "Discounts",
                column: "PlatformGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_GameId",
                table: "PlatformGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_PlatformId",
                table: "PlatformGame",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "PlatformGame");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
