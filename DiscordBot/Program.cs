using System;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using Discord.WebSocket;
using Discord.Commands;


namespace DiscordBot
{
    class Program
    {
        private CommandService commands;
        private DiscordSocketClient client;

        static void Main(string[] args)
        => new Program().Start()
            .GetAwaiter()
            .GetResult();


        private async Task Start()
        {

            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });


            client.MessageReceived += Client_MessageReceived;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());

            client.Ready += Client_Ready;
            client.Log += Client_Log;


            // create an empty string to fill from file info
            string Token = string.Empty;

            // use file stream to fill the token informaiton so that it is not exposed, add file to Git ignore
            using (var Stream = new FileStream((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Replace(@"bin\Debug\netcoreapp2.0", @"Data\Token.txt"), FileMode.Open, FileAccess.Read))
            using (var ReadToken = new StreamReader(Stream))
            {
                Token = ReadToken.ReadToEnd();
            }

            await client.LoginAsync(TokenType.Bot, Token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

        private async Task Client_Ready()
        {
            await client.SetGameAsync("Bulletbot - Test!", "https://www.twitch.tv/KobeKO", StreamType.NotStreaming);
        }

        private async Task Client_MessageReceived(SocketMessage MessageParam)
        {
            var message = MessageParam as SocketUserMessage;
            var context = new SocketCommandContext(client, message);

            if (context.Message == null || context.Message.Content == string.Empty) return;
            if (context.User.IsBot) return;

            int ArgPos = 0;

            if (!(message.HasStringPrefix("!", ref ArgPos) || message.HasMentionPrefix(client.CurrentUser, ref ArgPos))) return;

            var Result = await commands.ExecuteAsync(context, ArgPos);
            if (!Result.IsSuccess)
            {
                Console.WriteLine($"{DateTime.Now} ] !!! Something went wrong with executing a command. Text: {context.Message.Content} | Error: {Result.ErrorReason}");
            }
        }

    }

}