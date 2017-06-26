using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoormanBot
{
    class MyBot
    {
        DiscordClient discord;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi!");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzI4NjkwMTg2NzIyNzM4MTc2.DDHsSA.Fd9jFjvWdgPoBM36jy6GnpSCDWg", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
