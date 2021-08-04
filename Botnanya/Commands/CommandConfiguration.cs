using System;
namespace Botnanya.Commands
{
    /// <summary>
    /// Command configuration representation
    /// </summary>
    public class CommandConfiguration
    {
        /// <summary>
        /// Prefix of the commands
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="prefix">Prefix of the commands</param>
        public CommandConfiguration(string prefix)
        {
            this.Prefix = prefix;
        }

        /// <summary>
        /// Checks if a given input is a command with the right prefix and right trigger
        /// This doesn't checks arguments.
        /// </summary>
        /// <param name="trigger">Text command</param>
        /// <param name="input">User input</param>
        /// <returns>True if the command is valid or false if not.</returns>
        public bool IsCommand(string trigger, string input)
        {
            return input.StartsWith(this.Prefix + trigger);
        }
    }
}
