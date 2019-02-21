using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Core.Commands
{
    public class ShoutoutDad : ModuleBase<SocketCommandContext>
    {
        [Command("so"), Alias("so", "shoutout", "shout out"), Summary("Make a shoutout!")]    

        public async Task shoutOutDad()
        {
            await Context.Channel.SendMessageAsync(@"Shout out to my dad, @Bulletsponge, for making me who I am today!");
        }
    }
}
