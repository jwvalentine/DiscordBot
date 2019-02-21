using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Core.Commands
{
    public class MyEmbed : ModuleBase<SocketCommandContext>
    {
        [Command("embed"), Summary("Embed test command")]

        public async Task embed()
        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor("KobeKO is headed to GMs!", Context.User.GetAvatarUrl());
            Embed.WithColor(40,200,150);
            Embed.WithFooter("Be sure to follow!", Context.Guild.Owner.GetAvatarUrl());
            Embed.WithDescription("Probably the most flex DPS/Healer I've ever seen. [Check him out on Twitch!](https://www.twitch.tv/KobeKO)");
            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
    }
}
