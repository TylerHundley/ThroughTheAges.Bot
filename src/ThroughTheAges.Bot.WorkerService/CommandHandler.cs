using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ThroughTheAges.Bot.WorkerService
{
  public class CommandHandler
  {
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commands;
    private readonly IServiceProvider _services;
    private readonly string _prefix;

    public CommandHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services, IConfiguration config)
    {
      _client = client;
      _commands = commands;
      _services = services;
      _prefix = config["BotSettings:Prefix"];

      _client.MessageReceived += HandleCommandAsync;
    }

    public async Task LoadCommandsAsync()
    {
      await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }

    private async Task HandleCommandAsync(SocketMessage messageParam)
    {
      //system message check
      var message = messageParam as SocketUserMessage;
      if (message == null) return;

      int argPos = 0;

      if (message.Author.IsBot) return;

      if (!(message.HasStringPrefix(_prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;

      var context = new SocketCommandContext(_client, message);
      var result = await _commands.ExecuteAsync(context, argPos, _services);

      if (!result.IsSuccess)
      {
        await context.Channel.SendMessageAsync(result.ErrorReason);
      }
    }
  }
}
