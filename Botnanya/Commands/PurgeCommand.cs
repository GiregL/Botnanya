using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Exceptions;

namespace Botnanya.Commands
{
    /// <summary>
    /// Purge command
    /// </summary>
    public class PurgeCommand : BaseCommandModule
    {
        [Command("purge")]
        public async Task Purge(CommandContext context, int amount)
        {
            var messages = await context.Channel.GetMessagesBeforeAsync(((ulong)DateTime.Now.Millisecond), amount);
            try
            {
                await context.Channel.DeleteMessagesAsync(messages);
            } catch (BadRequestException e)
            {
                await context.Message.RespondAsync($"Error: bad request: `{e.Message}`");
            } catch (UnauthorizedException e)
            {
                await context.Message.RespondAsync($"Error: not permitted: `{e.Message}`");
            } catch (ServerErrorException e)
            {
                await context.Message.RespondAsync($"Error: serveur error: `{e.Message}`");
            } catch (NotFoundException e)
            {
                await context.Message.RespondAsync($"Error: messages not found: `{e.Message}`");
            }
            
        }
    }
}
