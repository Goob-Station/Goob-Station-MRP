using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class RMCPatreon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rmc_discord_accounts",
                columns: table => new
                {
                    rmc_discord_accounts_id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_discord_accounts", x => x.rmc_discord_accounts_id);
                });

            migrationBuilder.CreateTable(
                name: "rmc_linking_codes",
                columns: table => new
                {
                    player_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    code = table.Column<Guid>(type: "TEXT", nullable: false),
                    creation_time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_linking_codes", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_rmc_linking_codes_player_player_id",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rmc_patron_tiers",
                columns: table => new
                {
                    rmc_patron_tiers_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    show_on_credits = table.Column<bool>(type: "INTEGER", nullable: false),
                    ghost_color = table.Column<bool>(type: "INTEGER", nullable: false),
                    lobby_message = table.Column<bool>(type: "INTEGER", nullable: false),
                    round_end_shoutout = table.Column<bool>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    discord_role = table.Column<ulong>(type: "INTEGER", nullable: false),
                    priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_patron_tiers", x => x.rmc_patron_tiers_id);
                });

            migrationBuilder.CreateTable(
                name: "rmc_linked_accounts",
                columns: table => new
                {
                    player_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    discord_id = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_linked_accounts", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_rmc_linked_accounts_player_player_id",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rmc_linked_accounts_rmc_discord_accounts_discord_id",
                        column: x => x.discord_id,
                        principalTable: "rmc_discord_accounts",
                        principalColumn: "rmc_discord_accounts_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rmc_linked_accounts_logs",
                columns: table => new
                {
                    rmc_linked_accounts_logs_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    player_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    discord_id = table.Column<ulong>(type: "INTEGER", nullable: false),
                    at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_linked_accounts_logs", x => x.rmc_linked_accounts_logs_id);
                    table.ForeignKey(
                        name: "FK_rmc_linked_accounts_logs_player_player_id1",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rmc_linked_accounts_logs_rmc_discord_accounts_discord_id",
                        column: x => x.discord_id,
                        principalTable: "rmc_discord_accounts",
                        principalColumn: "rmc_discord_accounts_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rmc_patrons",
                columns: table => new
                {
                    player_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    tier_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ghost_color = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_patrons", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_rmc_patrons_player_player_id",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rmc_patrons_rmc_patron_tiers_tier_id",
                        column: x => x.tier_id,
                        principalTable: "rmc_patron_tiers",
                        principalColumn: "rmc_patron_tiers_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rmc_patron_lobby_messages",
                columns: table => new
                {
                    patron_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    message = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_patron_lobby_messages", x => x.patron_id);
                    table.ForeignKey(
                        name: "FK_rmc_patron_lobby_messages_rmc_patrons_patron_id",
                        column: x => x.patron_id,
                        principalTable: "rmc_patrons",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rmc_patron_round_end_nt_shoutouts",
                columns: table => new
                {
                    patron_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rmc_patron_round_end_nt_shoutouts", x => x.patron_id);
                    table.ForeignKey(
                        name: "FK_rmc_patron_round_end_nt_shoutouts_rmc_patrons_patron_id",
                        column: x => x.patron_id,
                        principalTable: "rmc_patrons",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rmc_linked_accounts_discord_id",
                table: "rmc_linked_accounts",
                column: "discord_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rmc_linked_accounts_logs_at",
                table: "rmc_linked_accounts_logs",
                column: "at");

            migrationBuilder.CreateIndex(
                name: "IX_rmc_linked_accounts_logs_discord_id",
                table: "rmc_linked_accounts_logs",
                column: "discord_id");

            migrationBuilder.CreateIndex(
                name: "IX_rmc_linked_accounts_logs_player_id",
                table: "rmc_linked_accounts_logs",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_rmc_linking_codes_code",
                table: "rmc_linking_codes",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_rmc_patron_tiers_discord_role",
                table: "rmc_patron_tiers",
                column: "discord_role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rmc_patrons_tier_id",
                table: "rmc_patrons",
                column: "tier_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rmc_linked_accounts");

            migrationBuilder.DropTable(
                name: "rmc_linked_accounts_logs");

            migrationBuilder.DropTable(
                name: "rmc_linking_codes");

            migrationBuilder.DropTable(
                name: "rmc_patron_lobby_messages");

            migrationBuilder.DropTable(
                name: "rmc_patron_round_end_nt_shoutouts");

            migrationBuilder.DropTable(
                name: "rmc_discord_accounts");

            migrationBuilder.DropTable(
                name: "rmc_patrons");

            migrationBuilder.DropTable(
                name: "rmc_patron_tiers");
        }
    }
}
