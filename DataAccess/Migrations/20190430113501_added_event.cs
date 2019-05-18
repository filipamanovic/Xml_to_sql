using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class added_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TournamentId = table.Column<string>(maxLength: 32, nullable: false),
                    utc_scheduled = table.Column<DateTime>(nullable: false),
                    id_competitor_host = table.Column<string>(maxLength: 32, nullable: false),
                    id_competitor_guest = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Competitors_id_competitor_guest",
                        column: x => x.id_competitor_guest,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Competitors_id_competitor_host",
                        column: x => x.id_competitor_host,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_TournamentId",
                table: "Events",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_id_competitor_guest",
                table: "Events",
                column: "id_competitor_guest");

            migrationBuilder.CreateIndex(
                name: "IX_Events_id_competitor_host",
                table: "Events",
                column: "id_competitor_host");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
