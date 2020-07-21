using Discord;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.Text;
using ThroughTheAges.Bot.Enums;
using ThroughTheAges.Bot.Models;

namespace ThroughTheAges.Bot.Services
{
  public class CardFormatService
  {
    public Embed FormatCard(Card card)
    {
      var color = card.Category.GetAttributes().Get<ColorAttribute>();

      var builder = new EmbedBuilder()
        .WithTitle(card.Name)
        .WithDescription($"Age {card.Age.GetName()} {card.Type.GetName()} - {card.Category.GetName()} ({card.CountTwoPlayers}/{card.CountThreePlayers}/{card.CountFourPlayers})")
        .WithColor(color.Red, color.Green, color.Blue)
        .AddField(x =>
        {
          x.Name = "Cost";
          x.Value = $":bulb: {card.TechCost} {(card.Category == CardCategory.Government ? $"({card.RevolutionCost}) " : "")}| <:rock:733843254029844490> {card.BuildCost}{(string.IsNullOrWhiteSpace(card.BuildSteps) ? "" : $" ({card.BuildSteps})")}";
        })
        .AddField(x =>
        {
          x.Name = "Production";
          x.Value = $":canned_food: {card.FoodProduction} | <:rock:733843254029844490> {card.ResourceProduction} | <:laurel_wreath:733843253773992027> {card.CultureProduction} | :shield: {card.StrengthProduction} | :bulb: {card.ScienceProduction}";
        });

      var sb = new StringBuilder()
        .LoopAddEmoji(card.Happiness, ":smile:")
        .LoopAddEmoji(card.Discontent, ":neutral_face:")
        .LoopAddEmoji(card.Colonization, ":sailboat:")
        .LoopAddEmoji(card.CivilActions, ":white_circle:", true)
        .LoopAddEmoji(card.MilitaryActions, ":red_circle:", true)
        .LoopAddEmoji(card.BlueTokens, ":blue_circle:", true)
        .LoopAddEmoji(card.YellowTokens, ":yellow_circle:", true);

      if (card.Category == CardCategory.Government)
      {
        sb.LoopAddEmoji(card.BuildingLimit, ":house:");
      }

      var value = sb.ToString().TrimEnd('|');

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
          sb.Append($" **{(count > 0 ? "+ " : "- ")}**");
        }
        else
        {
          sb.Append(" ");
        }
        for (int i = 0; i < Math.Abs(count); i++)
        {
          sb.Append($"{emoji}");
        }
        sb.Append(" |");
      }
      return sb;
    }
  }
}
