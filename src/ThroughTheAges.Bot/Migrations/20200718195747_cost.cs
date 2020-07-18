using Microsoft.EntityFrameworkCore.Migrations;

namespace ThroughTheAges.Bot.Migrations
{
    public partial class cost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildCost",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 1,
                columns: new[] { "BuildCost", "BuildSteps" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 2,
                columns: new[] { "BuildCost", "BuildSteps" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 3,
                columns: new[] { "BuildCost", "BuildSteps" },
                values: new object[] { 21, null });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 4,
                column: "BuildCost",
                value: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildCost",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 1,
                column: "BuildSteps",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 2,
                column: "BuildSteps",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 3,
                column: "BuildSteps",
                value: "21");
        }
    }
}
