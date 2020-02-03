using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VRGameDeals.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Games_GameId",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_GameId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "StandardPrice",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Discounts");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "PlatformGame",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameGuid",
                table: "Discounts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlatformGameId",
                table: "Discounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame",
                column: "Guid");

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
                values: new object[] { new Guid("2ec89778-58f2-4e5a-af36-ed55d46f7ff9"), new Guid("26f2a34c-7f9f-40e6-aeca-6a875ace5be9"), new Guid("c4149c8f-b816-4c75-ae8d-94c9b7d18c9b"), 99m, new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_GameId",
                table: "PlatformGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_GameGuid",
                table: "Discounts",
                column: "GameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_PlatformGameId",
                table: "Discounts",
                column: "PlatformGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Games_GameGuid",
                table: "Discounts",
                column: "GameGuid",
                principalTable: "Games",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_PlatformGame_PlatformGameId",
                table: "Discounts",
                column: "PlatformGameId",
                principalTable: "PlatformGame",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Games_GameGuid",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_PlatformGame_PlatformGameId",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame");

            migrationBuilder.DropIndex(
                name: "IX_PlatformGame_GameId",
                table: "PlatformGame");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_GameGuid",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_PlatformGameId",
                table: "Discounts");

            migrationBuilder.DeleteData(
                table: "PlatformGame",
                keyColumn: "Guid",
                keyValue: new Guid("2ec89778-58f2-4e5a-af36-ed55d46f7ff9"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Guid",
                keyValue: new Guid("26f2a34c-7f9f-40e6-aeca-6a875ace5be9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Guid",
                keyValue: new Guid("c4149c8f-b816-4c75-ae8d-94c9b7d18c9b"));

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "PlatformGame");

            migrationBuilder.DropColumn(
                name: "GameGuid",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "PlatformGameId",
                table: "Discounts");

            migrationBuilder.AddColumn<decimal>(
                name: "StandardPrice",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Discounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame",
                columns: new[] { "GameId", "PlatformId" });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_GameId",
                table: "Discounts",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Games_GameId",
                table: "Discounts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
