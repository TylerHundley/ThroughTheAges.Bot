using System;
using System.Collections.Generic;
using System.Text;

namespace ThroughTheAges.Bot.Enums
{
  public enum CardCategory
  {
    [Color(178, 127, 74)]
    Farm = 1,
    [Color(178, 127, 74)]
    Mine = 2,
    [Color(157, 157, 157)]
    Lab = 3,
    [Color(157, 157, 157)]
    Temple = 4,
    [Color(157, 157, 157)]
    Arena = 5,
    [Color(157, 157, 157)]
    Library = 6,
    [Color(157, 157, 157)]
    Theater = 7,
    [Color(218, 82, 75)]
    Infantry = 8,
    [Color(218, 82, 75)]
    Cavalry = 9,
    [Color(218, 82, 75)]
    Artillery = 10,
    [Color(218, 82, 75)]
    AirForce = 11,
    [Color(218, 127, 68)]
    Government = 12,
    [Color(4, 170, 216)]
    Military = 13,
    [Color(4, 170, 216)]
    Civil = 14,
    [Color(4, 170, 216)]
    Colonization = 15,
    [Color(4, 170, 216)]
    Construction = 16,
    [Color(135, 112, 171)]
    Wonder = 17,
    [Color(114, 163, 77)]
    Leader = 18,
    [Color(219, 179, 67)]
    Action = 19,
    [Color(94, 171, 41)]
    Bonus = 20,
    [Color(128, 85, 68)]
    Aggression = 21,
    [Color(67, 67, 65)]
    War = 22,
    [Color(35, 48, 76)]
    Pact = 23,
    [Color(98, 37, 37)]
    Tactic = 24,
    [Color(35, 58, 24)]
    Event = 25
  }

  [AttributeUsage(AttributeTargets.Field)]
  class ColorAttribute : Attribute
  {
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }

    public ColorAttribute(int r, int g, int b)
    {
      Red = r;
      Green = g;
      Blue = b;
    }
  }
}
