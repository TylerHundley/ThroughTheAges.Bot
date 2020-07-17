using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThroughTheAges.Bot.WorkerService.Modules
{
  public class InfoModule : ModuleBase<SocketCommandContext>
  {
    [Command("say")]
    [Summary("Echoes a message.")]
    public Task SayAsync([Remainder][Summary("The text to echo.")] string echo)
    {
      return ReplyAsync(echo);
    }

    [Command("tta")]
    public Task TestAsync([Remainder] string search)
    {
      var hits = Regex.Matches(search, @"\[(.*?)\]").Cast<Match>().Select(x => x.Groups[1].Value).Where(y => y.Any()).ToList();
      var searches = new StringBuilder().AppendJoin(',', hits).ToString();
      return ReplyAsync($"Searching for: {searches}");
    }
  }
}
