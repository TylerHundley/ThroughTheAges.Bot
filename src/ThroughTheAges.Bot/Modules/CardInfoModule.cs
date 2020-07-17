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

    public CardInfoModule(CardSearchService cardSearchService)
    {
      _cardSearchService = cardSearchService;
    }

    [Command("tta")]
    [Summary("Retrieves card data for any names identified by [brackets]")]
    public async Task SendCardInfo([Remainder] string message)
    {
      var hits = Regex.Matches(message, @"\[(.*?)\]").Cast<Match>().Select(x => x.Groups[1].Value).Where(y => y.Any()).ToList();

      foreach (var name in hits)
      {
        await ReplyAsync(await _cardSearchService.GetCardDataAsync(name));
      }
    }

  }
}
