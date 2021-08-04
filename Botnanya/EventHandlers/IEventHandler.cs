using System;
using Botnanya.Commands;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace Botnanya.EventHandlers
{
    public enum EventType
    {
        MessageCreated,
        MessageDeleted,
        GlobalEvent,
    }

    /// <summary>
    /// Interface representing an event handler
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Event type of the EventHandler instance
        /// </summary>
        /// <returns>EventType of the instance</returns>
        public EventType GetEventType();

        /// <summary>
        /// Sets the command configuration for the given event handler
        /// </summary>
        /// <param name="commandConfiguration">Command configuration instance</param>
        public void SetCommandConfig(CommandConfiguration commandConfiguration);

        /// <summary>
        /// Global trigger of the event.
        /// </summary>
        public async virtual void OnGlobalTrigger(DiscordClient client, EventArgs eArgs) { }

        /// <summary>
        /// On Message Created event handler
        /// </summary>
        /// <param name="client">Discord client</param>
        /// <param name="message">Message created</param>
        public async virtual void OnMessageCreated(DiscordClient client, MessageCreateEventArgs message) { }

        /// <summary>
        /// On Message Deleted event handler
        /// </summary>
        /// <param name="client">Discord client</param>
        /// <param name="message">Message deleted</param>
        public async virtual void OnMessageDeleted(DiscordClient client, MessageDeleteEventArgs message) { }
    }
}
