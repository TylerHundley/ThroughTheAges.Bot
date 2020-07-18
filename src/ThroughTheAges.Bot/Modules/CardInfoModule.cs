using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ThroughTheAges.Bot.Services;

namespace ThroughTheAges.Bot.Modules
{
  
  public class CardInfoModule : ModuleBase<SocketCommandContext>
  {
    private readonly CardSearchService _cardSearchService;
    private readonly CardFormatService _cardFormatService;

    public CardInfoModule(CardSearchService cardSearchService, CardFormatService cardFormatService)
    {
      _cardSearchService = cardSearchService;
      _cardFormatService = cardFormatService;
    }

    [Command("tta")]
    [Summary("Retrieves card data for any names identified by [brackets]")]
    public async Task SearchTheMessage([Remainder] string message)
    {
      await SendCardInfo(message);
    }

    [Command("get-tta")]
    public async Task SearchAMessageAsync(ulong messageId)
    {
      var message = await Context.Channel.GetMessageAsync(messageId);
      await SendCardInfo(message.Content);
    }

    public async Task SendCardInfo(string message)
    {
      var hits = Regex.Matches(message, @"\[(.*?)\]").Cast<Match>().Select(x => x.Groups[1].Value).Where(y => y.Any()).ToList();

      foreach (var name in hits)
      {
        var card = await _cardSearchService.GetCardDataAsync(name);

        if (card == null)
        {
          await ReplyAsync($"{name} not found");
        }
        else
        {
          await ReplyAsync(embed: _cardFormatService.FormatCard(card));
        }
      }
    }

  }
}
