using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Core.Commands
{
    public class JFJ : ModuleBase<SocketCommandContext>
    {
        [Command("JFJ"), Alias("jfj", "JFJ", "Joke"), Summary("Jeff Foxworthy Jokes")]    

        public async Task JFJs()
        {
            var jokes = new List<string>();

        // hard coded list of jokes for now, but later to be implemented as a file list
        #region JOKES GO HERE FOR NOW
            jokes.Add("You might be a redneck if...  you've ever written your resume on a cocktail napkin.");
            jokes.Add("You might be a redneck if...  you advertise on the inside walls of portable toilets.");
            jokes.Add("You might be a redneck if...  you ask to open a savings account and the teller says, 'With what?'");
            jokes.Add("You might be a redneck if...  you carry a case of beer to your tax audit.");
            jokes.Add("You might be a redneck if...  you dont need a clean shirt to go to work.");
            jokes.Add("You might be a redneck if...  your wife's job requires her to wear an orange vest.");
            jokes.Add("You might be a redneck if...  every job you've had paid daily.");
            jokes.Add("You might be a redneck if... you thought the stock market had a fence around it.");
            jokes.Add("If the biggest sign on your place of business says 'Minnows'... you might be a redneck.");
            jokes.Add("If you list 'Beginners Luck' as a skill on your resume... you might be a redneck.");
            jokes.Add("If you pend 40-hours a week at Wal-Mart, but you don't work there...  you might be a redneck.");
            jokes.Add("If you see a sign that says 'Say no to crack' and it reminds you to pull up your jeans... you might be a redneck.");
            jokes.Add("If three generations of your family are workin' at McDonalds... you might be a redneck.");
            jokes.Add("If you're late for work because a cow was layin' in the middle of the road, you might be a redneck.");

            #endregion

            Random r = new Random();
            await Context.Channel.SendMessageAsync(jokes[r.Next(jokes.Count)]);
        }
    }
}
