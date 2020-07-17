using Microsoft.EntityFrameworkCore.Migrations;

namespace ThroughTheAges.Bot.Migrations
{
    public partial class initSqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    CountTwoPlayers = table.Column<int>(nullable: false),
                    CountThreePlayers = table.Column<int>(nullable: false),
                    CountFourPlayers = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    TechCost = table.Column<int>(nullable: false),
                    BuildCost = table.Column<string>(nullable: true),
                    FoodProduction = table.Column<int>(nullable: false),
                    ResourceProduction = table.Column<int>(nullable: false),
                    CultureProduction = table.Column<int>(nullable: false),
                    StrengthProduction = table.Column<int>(nullable: false),
                    ScienceProduction = table.Column<int>(nullable: false),
                    Happiness = table.Column<int>(nullable: false),
                    CivilActions = table.Column<int>(nullable: false),
                    MilitaryActions = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 1, 1, "3", 5, 0, 2, 2, 1, 0, 0, 2, 0, "Bread & Circuses", 0, 0, 1, 3, "", 1 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Age", "BuildCost", "Category", "CivilActions", "CountFourPlayers", "CountThreePlayers", "CountTwoPlayers", "CultureProduction", "FoodProduction", "Happiness", "MilitaryActions", "Name", "ResourceProduction", "ScienceProduction", "StrengthProduction", "TechCost", "Text", "Type" },
                values: new object[] { 2, 1, "3", 6, 0, 2, 2, 2, 1, 0, 0, 0, "Printing Press", 0, 1, 0, 3, "", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
