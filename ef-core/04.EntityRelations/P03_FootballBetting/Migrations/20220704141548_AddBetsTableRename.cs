using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class AddBetsTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Games_GameId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Users_UserId",
                table: "Bet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bet",
                table: "Bet");

            migrationBuilder.RenameTable(
                name: "Bet",
                newName: "Bets");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UserId",
                table: "Bets",
                newName: "IX_Bets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_GameId",
                table: "Bets",
                newName: "IX_Bets_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bets",
                table: "Bets",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bets",
                table: "Bets");

            migrationBuilder.RenameTable(
                name: "Bets",
                newName: "Bet");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_UserId",
                table: "Bet",
                newName: "IX_Bet_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_GameId",
                table: "Bet",
                newName: "IX_Bet_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bet",
                table: "Bet",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Games_GameId",
                table: "Bet",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Users_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
