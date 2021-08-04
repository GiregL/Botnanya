using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Botnanya.EventHandlers;
using Botnanya.Commands;
using System.Linq;
using System.Reflection;
using DSharpPlus.CommandsNext;

namespace Botnanya
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Loading environment
            string discordToken = System.Environment.GetEnvironmentVariable("DISCORD_TOKEN");
            if (discordToken == null)
            {
                Console.WriteLine($"ERROR: Discord token not given.");
                return;
            }

            // Bot main
            MainAsync(discordToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// All the event handlers instances of the bot
        /// </summary>
        /// <returns>Event Handlers</returns>
        static IEnumerable<IEventHandler> EventHandlers()
        {
            IList<IEventHandler> handlers = new List<IEventHandler>();

            var commandConfig = new CommandConfiguration("$");

            var assemblyTypes = Assembly.GetAssembly(typeof(IEventHandler)).GetTypes();
            var eventHandlerClasses = from types in assemblyTypes
                                      where typeof(IEventHandler).IsAssignableFrom(types)
                                      && types != typeof(IEventHandler)
                                      select types;

            foreach (Type type in eventHandlerClasses)
            {
                IEventHandler handler = (IEventHandler)Activator.CreateInstance(type);
                handler.SetCommandConfig(commandConfig);
                handlers.Add(handler);
            }

            return handlers;
        }

        /// <summary>
        /// List of all event handlers that processes MessageCreateEvent
        /// </summary>
        /// <returns>Event handlers</returns>
        static IEnumerable<IEventHandler> MessageCreateEventHandlers()
        {
            var handlers = EventHandlers();
            return (from handler in handlers
                    where handler.GetEventType() == EventType.MessageCreated
                    select handler
                );
        }

        /// <summary>
        /// Entry point of the bot
        /// </summary>
        /// <param name="discordToken">Discord token</param>
        /// <returns>Async main task</returns>
        static async Task MainAsync(string discordToken)
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = discordToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration {
                StringPrefixes = new[] {"$"}
            });

            commands.RegisterCommands<PurgeCommand>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
