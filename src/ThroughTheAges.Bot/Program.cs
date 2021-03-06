﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using System.IO;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.DependencyInjection;
using ThroughTheAges.Bot.Services;
using Discord.Addons.Interactive;
using ThroughTheAges.Bot.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ThroughTheAges.Bot
{
  class Program
  {
    static async Task Main()
    {
      var builder = new HostBuilder()
        .ConfigureAppConfiguration(x =>
        {
          var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", false, true)
              .AddJsonFile("appsettings.development.json", true, true)
              .Build();

          x.AddConfiguration(configuration);
        })
        .UseSerilog((context, config) =>
        {
          config
          .WriteTo.Console()
          .MinimumLevel.Verbose()
          .MinimumLevel.Override("Microsoft", LogEventLevel.Error);
        })
        .ConfigureDiscordHost<DiscordSocketClient>((context, config) =>
        {
          config.SocketConfig = new DiscordSocketConfig
          {
            LogLevel = LogSeverity.Info,
            AlwaysDownloadUsers = true,
            MessageCacheSize = 200
          };

          config.Token = context.Configuration["token"];
        })
        .UseCommandService((context, config) =>
        {
          config.LogLevel = LogSeverity.Verbose;
          config.DefaultRunMode = RunMode.Async;
        })
        .ConfigureServices((context, services) =>
        {
          services
            .AddHostedService<CommandHandler>()
            .AddSingleton<InteractiveService>()
            .AddSingleton<CardSearchService>()
            .AddTransient<CardFormatService>()
            .AddSingleton<Helper>()
            .AddDbContext<CardContext>(options =>
             {
               options.UseSqlite(context.Configuration.GetConnectionString("SqliteTestCards"));
             }, ServiceLifetime.Transient);
        });

      var host = builder.Build();
      using (host)
      {
        await host.MigrateDatabase<CardContext>().RunAsync();
      }
    }
  }

  public static class Extensions
  {
    public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        try
        {
          var db = services.GetRequiredService<T>();
          db.Database.Migrate();
        }
        catch (Exception ex)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred while migrating the database.");
        }
      }
      return host;
    }
  }
}
