using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Core.Commands
{
    public class HelloWorld : ModuleBase<SocketCommandContext>
    {
        [Command("Hello"), Alias("hello", "world"), Summary("Hello World Command")]
        public async Task helloWorld()
        {
            await Context.Channel.SendMessageAsync("Hello World!");
        }
    }
}
