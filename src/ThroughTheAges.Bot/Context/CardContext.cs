using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using ThroughTheAges.Bot.Models;

namespace ThroughTheAges.Bot.Context
{
  public class CardContext : DbContext
  {
    public CardContext(DbContextOptions<CardContext> options) : base(options) { }

    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Card>()
        .HasData(
          new Card
          {
            CardId = 1,
            Name = "Bread & Circuses",
            Type = CardType.Civil,
            Category = CardCategory.Arena,
            CountTwoPlayers = 1,
            CountThreePlayers = 2,
            CountFourPlayers = 2,
            Age = Age.I,
            TechCost = 3,
            BuildCost = "3",
            FoodProduction = 0,
            ResourceProduction = 0,
            CultureProduction = 0,
            StrengthProduction = 1,
            ScienceProduction = 0,
            Happiness = 2,
            Discontent = 0,
            CivilActions = 0,
            MilitaryActions = 0,
            Text = ""
          },
          new Card
          {
            CardId = 2,
            Name = "Printing Press",
            Type = CardType.Civil,
            Category = CardCategory.Library,
            CountTwoPlayers = 2,
            CountThreePlayers = 2,
            CountFourPlayers = 2,
            Age = Age.I,
            TechCost = 3,
            BuildCost = "3",
            FoodProduction = 0,
            ResourceProduction = 0,
            CultureProduction = 1,
            StrengthProduction = 0,
            ScienceProduction = 1,
            Happiness = 0,
            Discontent = 0,
            CivilActions = 0,
            MilitaryActions = 0,
            Text = ""
          },
          new Card
          {
            CardId = 3,
            Name = "Test Card",
            Type = CardType.Military,
            Category = CardCategory.Leader,
            CountTwoPlayers = 1,
            CountThreePlayers = 2,
            CountFourPlayers = 3,
            Age = Age.II,
            TechCost = 3,
            BuildCost = "21",
            FoodProduction = 2,
            ResourceProduction = 1,
            CultureProduction = 1,
            StrengthProduction = 4,
            ScienceProduction = 1,
            Happiness = 3,
            Discontent = 1,
            CivilActions = -1,
            MilitaryActions = 2,
            Text = "This is some special text"
          },
          new Card
          {
            CardId = 4,
            Name = "Test Wonder",
            Type = CardType.Civil,
            Category = CardCategory.Wonder,
            CountTwoPlayers = 1,
            CountThreePlayers = 1,
            CountFourPlayers = 1,
            Age = Age.III,
            TechCost = 3,
            BuildCost = "4-1-1-4",
            FoodProduction = 0,
            ResourceProduction = 0,
            CultureProduction = 2,
            StrengthProduction = 0,
            ScienceProduction = 0,
            Happiness = 0,
            Discontent = 1,
            CivilActions = 0,
            MilitaryActions = 0,
            Text = "Does something really cool"
          }
        );
    }
  }
  public class BotContextFactory : IDesignTimeDbContextFactory<CardContext>
  {
    public CardContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<CardContext>().UseSqlite("Data Source = TestCards.db");
      return new CardContext(optionsBuilder.Options);
    }
  }
}
