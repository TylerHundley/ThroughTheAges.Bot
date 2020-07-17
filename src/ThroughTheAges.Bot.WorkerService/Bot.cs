using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThroughTheAges.Bot.WorkerService.Services;

namespace ThroughTheAges.Bot.WorkerService
{
  public class Bot : IHostedService
  {
    private readonly DiscordSocketClient _client;
    private readonly IServiceProvider _services;
    private readonly string _token;

    public Bot(DiscordSocketClient client, IServiceProvider services, IConfiguration config)
    {
      _client = client;
      _services = services;
      _token = config["BotSettings:Token"];
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      await _services.GetRequiredService<CommandHandler>().InitializeAsync(default);
      await _client.LoginAsync(TokenType.Bot, _token);
      await _client.StartAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
      await _client.StopAsync();
      await _client.LogoutAsync();
    }
  }
}
