using EnumsNET;
using System;
using System.Collections.Generic;
using System.Text;
using ThroughTheAges.Bot.Enums;

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
    public int BuildCost { get; set; }
    public string BuildSteps { get; set; } = null;
    public int FoodProduction { get; set; }
    public int ResourceProduction { get; set; }
    public int CultureProduction { get; set; }
    public int StrengthProduction { get; set; }
    public int ScienceProduction { get; set; }
    public int Happiness { get; set; }
    public int Discontent { get; set; }
    public int CivilActions { get; set; }
    public int MilitaryActions { get; set; }
    public string Text { get; set; }
  }
}
