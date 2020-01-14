﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VRGameDeals.Data.Migrations
{
    public partial class m10 : Migration
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
                    Description = table.Column<string>(nullable: true),
                    GameGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Platforms_Games_GameGuid",
                        column: x => x.GameGuid,
                        principalTable: "Games",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatformGame",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GameGuid = table.Column<Guid>(nullable: false),
                    PlatformGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformGame", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PlatformGame_Games_GameGuid",
                        column: x => x.GameGuid,
                        principalTable: "Games",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformGame_Platforms_PlatformGuid",
                        column: x => x.PlatformGuid,
                        principalTable: "Platforms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_GameGuid",
                table: "PlatformGame",
                column: "GameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGame_PlatformGuid",
                table: "PlatformGame",
                column: "PlatformGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_GameGuid",
                table: "Platforms",
                column: "GameGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformGame");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
