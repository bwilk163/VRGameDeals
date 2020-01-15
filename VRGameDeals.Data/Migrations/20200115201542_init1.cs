using Microsoft.EntityFrameworkCore.Migrations;

namespace VRGameDeals.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame");

            migrationBuilder.DropIndex(
                name: "IX_PlatformGame_GameGuid",
                table: "PlatformGame");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformGame",
                table: "PlatformGame",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_GameGuid",
                table: "PlatformGame",
                column: "GameGuid");
        }
    }
}
