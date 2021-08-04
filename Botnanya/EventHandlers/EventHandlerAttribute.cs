using System;
namespace Botnanya.EventHandlers
{
    /// <summary>
    /// Attribute representing all the event handlers of the Discord bot.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class)]
    public class EventHandlerAttribute : System.Attribute
    {
    }
}
