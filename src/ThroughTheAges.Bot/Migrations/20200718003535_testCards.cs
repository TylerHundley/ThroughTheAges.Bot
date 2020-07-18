using Microsoft.EntityFrameworkCore.Migrations;

namespace ThroughTheAges.Bot.Migrations
{
    public partial class testCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 3, 2, "3", 18, -1, 3, 2, 1, 1, 2, 3, 2, "Test Card", 1, 1, 4, 3, "This is some special text", 2 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 4, 3, "4 1 1 4", 17, 0, 1, 1, 1, 2, 0, 0, 0, "Test Wonder", 0, 0, 0, 3, "Does something really cool", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 4);
        }
    }
}
