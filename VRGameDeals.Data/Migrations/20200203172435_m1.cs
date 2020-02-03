using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VRGameDeals.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "StandardPrice",
                table: "Games",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Site = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Discounts_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_GameId",
                table: "Discounts",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropColumn(
                name: "StandardPrice",
                table: "Games");
        }
    }
}
