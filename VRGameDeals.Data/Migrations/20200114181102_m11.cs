using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VRGameDeals.Data.Migrations
{
    public partial class m11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Games_GameGuid",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_GameGuid",
                table: "Platforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame");

            migrationBuilder.DropIndex(
                name: "IX_PlatformGame_GameGuid",
                table: "PlatformGame");

            migrationBuilder.DropColumn(
                name: "GameGuid",
                table: "Platforms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame",
                columns: new[] { "GameGuid", "PlatformGuid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame");

            migrationBuilder.AddColumn<Guid>(
                name: "GameGuid",
                table: "Platforms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_GameGuid",
                table: "Platforms",
                column: "GameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_GameGuid",
                table: "PlatformGame",
                column: "GameGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Games_GameGuid",
                table: "Platforms",
                column: "GameGuid",
                principalTable: "Games",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
