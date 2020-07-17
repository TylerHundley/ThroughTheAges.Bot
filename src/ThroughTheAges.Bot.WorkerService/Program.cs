using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ThroughTheAges.Bot.WorkerService.Services;
using Discord.Addons.Hosting;
using System.IO;

namespace ThroughTheAges.Bot.WorkerService
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //var builder = new HostBuilder()
      //  .ConfigureAppConfiguration(x => 
      //  {
      //    var configuration = new ConfigurationBuilder()
      //      .SetBasePath(Directory.GetCurrentDirectory())
      //      .AddJsonFile("appsettings.json", false, true)
      //      .AddJsonFile($"appsettings.{""}.json", true, true)
      //      .Build();

      //    x.AddConfiguration(configuration);
      //  })
      //  .ConfigureLogging(x => 
      //  {
      //    x.AddConsole();
      //    x.SetMinimumLevel(LogLevel.Debug);
      //  })
      //  .ConfigureDiscordHost((hostContext, config) =>
      //  { 
      //    config.sock
      //  })


      CreateHostBuilder(args).Build().MigrateDatabase<CardContext>().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host
        .CreateDefaultBuilder(args)
        .ConfigureDiscordHost<DiscordSocketClient>((hostContext, config) =>
          {
            config.SocketConfig = new DiscordSocketConfig
            {
              LogLevel = LogSeverity.Verbose,
              AlwaysDownloadUsers = true,
              MessageCacheSize = 200
            };

            config.Token = hostContext.Configuration["BotSettings:Token"];
          })
        .UseCommandService()
        .ConfigureServices((hostContext, services) =>
          {
            services
              .AddDbContext<CardContext>(options =>
                {
                  options.UseSqlite(hostContext.Configuration.GetConnectionString("CardsConnectionSqlite"));

                }, ServiceLifetime.Transient)
              .AddTransient<SearchService>()
              .AddSingleton<DiscordSocketClient>()
              .AddSingleton<Helper>()
              //.AddSingleton<CommandHandler>()
              .AddHostedService<CommandHandler>();
          })
        .UseConsoleLifetime();
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
