using EnumsNET;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThroughTheAges.Bot.Models
{
  public class Card
  {
    public int CardId { get; set; }
    public string Name { get; set; }
    public CardType Type { get; set; }
    public CardCategory Category { get; set; }
    public int CountTwoPlayers { get; set; }
    public int CountThreePlayers { get; set; }
    public int CountFourPlayers { get; set; }
    public Age Age { get; set; }
    public int TechCost { get; set; }
    public string BuildCost { get; set; }
    public int FoodProduction { get; set; }
    public int ResourceProduction { get; set; }
    public int CultureProduction { get; set; }
    public int StrengthProduction { get; set; }
    public int ScienceProduction { get; set; }
    public int Happiness { get; set; }
    public int CivilActions { get; set; }
    public int MilitaryActions { get; set; }
    public string Text { get; set; }

    public override string ToString()
    {
      return new StringBuilder()
        .AppendLine(Name)
        .AppendLine($"{Age.GetName()}. {Type.GetName()} - {Category.GetName()}")
        .AppendLine($"Tech Cost: {TechCost}")
        .AppendLine($"Resource Cost: {BuildCost}")
        .AppendLine($"Food Production: {FoodProduction}")
        .AppendLine($"Resource Production: {ResourceProduction}")
        .AppendLine($"Culture Production: {CultureProduction}")
        .AppendLine($"Strength Production: {StrengthProduction}")
        .AppendLine($"Science Production: {ScienceProduction}")
        .AppendLine($"Happiness: {Happiness}")
        .AppendLine($"{CivilActions} CA, {MilitaryActions} MA")
        .AppendLine(Text)
        .ToString();
    }
  }

  public enum CardType
  {
    Civil = 1,
    Military = 2
  }

  public enum CardCategory
  {
    Farm = 1,
    Mine = 2,
    Lab = 3,
    Temple = 4,
    Arena = 5,
    Library = 6,
    Theater = 7,
    Infantry = 8,
    Cavalry = 9,
    Artillery = 10,
    AirForce = 11,
    Government = 12,
    Military = 13,
    Civil = 14,
    Colony = 15,
    Construction = 16,
    Wonder = 17,
    Leader = 18,
    Action = 19,
    Bonus = 20,
    Aggression = 21,
    War = 22,
    Pact = 23,
    Tactic = 24,
    Event = 25
  }

  public enum Age
  {
    A = 0,
    I = 1,
    II = 2,
    III = 3,
    IV = 4
  }
}
