using Microsoft.EntityFrameworkCore.Migrations;

namespace ThroughTheAges.Bot.Migrations
{
    public partial class discontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discontent",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 3,
                columns: new[] { "BuildCost", "Discontent" },
                values: new object[] { "21", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 4,
                columns: new[] { "BuildCost", "Discontent" },
                values: new object[] { "4-1-1-4", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discontent",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 3,
                column: "BuildCost",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 4,
                column: "BuildCost",
                value: "4 1 1 4");
        }
    }
}
