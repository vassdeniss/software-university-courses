using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class AddUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(5, 2)", nullable: false, defaultValue: 0.0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
