using Discord;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.Text;
using ThroughTheAges.Bot.Models;

namespace ThroughTheAges.Bot.Services
{
  public class CardFormatService
  {
    public Embed FormatCard(Card card)
    {
      var builder = new EmbedBuilder()
        .WithTitle(card.Name)
        .WithDescription($"Age {card.Age.GetName()} {card.Type.GetName()} - {card.Category.GetName()} ({card.CountTwoPlayers}/{card.CountThreePlayers}/{card.CountFourPlayers})")
        .AddField(x =>
        {
          x.Name = "Cost";
          x.Value = $":bulb: {card.TechCost} <:rock:733843254029844490> {card.BuildCost}";
        })
        .AddField(x =>
        {
          x.Name = "Production";
          x.Value = $":canned_food: {card.FoodProduction} <:rock:733843254029844490> {card.ResourceProduction} <:laurel_wreath:733843253773992027> {card.CultureProduction} :shield: {card.StrengthProduction} :bulb: {card.ScienceProduction}";
        });

      var value = new StringBuilder()
        .LoopAddEmoji(card.Happiness, ":smile:")
        .LoopAddEmoji(card.Discontent, ":neutral_face:")
        .LoopAddEmoji(card.CivilActions, ":white_circle:", true)
        .LoopAddEmoji(card.MilitaryActions, ":red_circle:", true)
        .ToString();

      if (!string.IsNullOrWhiteSpace(value))
      {
        builder.AddField(x =>
        {
          x.Name = "Bonuses";
          x.Value = value;
        });
      }

      if (!string.IsNullOrWhiteSpace(card.Text))
      {
        builder.AddField(x =>
        {
          x.Name = "Card Text";
          x.Value = card.Text;
        });
      }

      return builder.Build();
    }
  }

  public static class StringBuilderExtensions
  {
    public static StringBuilder LoopAddEmoji(this StringBuilder sb, int count, string emoji, bool showSign = false)
    {
      if (count != 0)
      {
        if (showSign)
        {
          sb.Append($" **{(count > 0 ? "+" : "-")}**");
        }
        for (int i = 0; i < Math.Abs(count); i++)
        {
          sb.Append($"{emoji} ");
        }
      }
      return sb;
    }
  }
}
