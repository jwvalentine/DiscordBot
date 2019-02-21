using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Core.Commands
{
    public class ShoutoutKobe : ModuleBase<SocketCommandContext>
    {
        [Command("KobeKO"), Alias("so Kobe", "soKobeKO", "soKobe"), Summary("Shout out to KobeKO")]    

        public async Task shoutOutKobe()
        {
            await Context.Channel.SendMessageAsync("Visit my man @Kobe on Twitch.tv/KobeKO - He's a great dude, give him a follow!");
        }
    }
}
