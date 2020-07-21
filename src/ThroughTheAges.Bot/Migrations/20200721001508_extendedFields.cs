using Microsoft.EntityFrameworkCore.Migrations;

namespace ThroughTheAges.Bot.Migrations
{
    public partial class extendedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "BlueTokens",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingLimit",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Colonization",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RevolutionCost",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowTokens",
                table: "Cards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlueTokens",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BuildingLimit",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Colonization",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "RevolutionCost",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "YellowTokens",
                table: "Cards");

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "BuildSteps", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "Discontent", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 1, 1, 3, null, 5, 0, 2, 2, 1, 0, 0, 0, 2, 0, "Bread & Circuses", 0, 0, 1, 3, "", 1 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "BuildSteps", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "Discontent", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 2, 1, 3, null, 6, 0, 2, 2, 2, 1, 0, 0, 0, 0, "Printing Press", 0, 1, 0, 3, "", 1 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "BuildSteps", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "Discontent", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 3, 2, 21, null, 18, -1, 3, 2, 1, 1, 1, 2, 3, 2, "Test Card", 1, 1, 4, 3, "This is some special text", 2 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "BuildSteps", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "Discontent", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 4, 3, 10, "4-1-1-4", 17, 0, 1, 1, 1, 2, 1, 0, 0, 0, "Test Wonder", 0, 0, 0, 3, "Does something really cool", 1 });
        }
    }
}
