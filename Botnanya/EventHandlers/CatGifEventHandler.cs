using System;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Botnanya.Commands;
using System.Net.Http;

namespace Botnanya.EventHandlers
{
    /// <summary>
    /// Cat gif event handler
    /// It sends a cat gif as replys to a given message.
    /// </summary>
    public class CatGifEventHandler : IEventHandler
    {
        /// <summary>
        /// Message to reply to.
        /// </summary>
        public string Trigger { get; }

        /// <summary>
        /// Command configuration instance
        /// </summary>
        public CommandConfiguration CommandConfiguration { get; set; }

        private HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tigger">Message to reply to.</param>
        public CatGifEventHandler()
        {
            this.Trigger = "cat";
            this._httpClient = new HttpClient();
        }

        /// <summary>
        /// Cat gif command.
        /// It replies a cat gif to the message when triggered.
        /// </summary>
        /// <param name="client">Discord client instance</param>
        /// <param name="message">Discord message</param>
        public async void OnMessageCreated(DiscordClient client, MessageCreateEventArgs message)
        {
            if (this.CommandConfiguration.IsCommand(this.Trigger, message.Message.Content.ToLower()))
            {
                var result = await this._httpClient.GetAsync("https://cataas.com/cat/gif");

                if ((int)result.StatusCode == 200)
                {
                    await message.Message.RespondAsync("Coming soon.");
                }
            }
        }

        /// <summary>
        /// Interface implementation
        /// <see cref="IEventHandler"/>
        /// </summary>
        /// <returns>EventType</returns>
        public EventType GetEventType()
        {
            return EventType.MessageCreated;
        }

        /// <summary>
        /// Interface implementation
        /// <see cref="IEventHandler"/>
        /// </summary>
        /// <param name="config"></param>
        public void SetCommandConfig(CommandConfiguration config)
        {
            this.CommandConfiguration = config;
        }
    }
}
