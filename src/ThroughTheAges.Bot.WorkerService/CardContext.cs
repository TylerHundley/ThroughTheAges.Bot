using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThroughTheAges.Bot.WorkerService.Models;

namespace ThroughTheAges.Bot.WorkerService
{
  public class CardContext : DbContext
  {
    public CardContext(DbContextOptions<CardContext> options) : base(options) { }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Card>().HasData(
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
            CivilActions = 0,
            MilitaryActions = 0,
            Text = ""
          }
        );
    }
  }
}
