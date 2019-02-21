using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Core.Commands
{
    public class ShoutOutCrowdia : ModuleBase<SocketCommandContext>
    {
        [Command("soCrowdia"), Alias("so", "shoutout", "shout out"), Summary("Make a shoutout!")]    

        public async Task shoutOutCrowdia()
        {
            await Context.Channel.SendMessageAsync("Shout out to my friend @Crowdia!  She's a whole hoot AND holler.  Follow her stream at Twitch.tv/Crowdia");
        }
    }
}
