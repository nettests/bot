using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace bot
{
    class Program
    {
		private DiscordSocketClient client;

        private MessageHandler handler;

        static void Main(string[] args)
        {
			new Program().StartAsync().GetAwaiter().GetResult();
        }

		private async Task StartAsync()
		{
			client = new DiscordSocketClient();

            
			await client.LoginAsync(TokenType.Bot, "NDUwNjUzNTMzNDk1MDk5Mzkz.De2cPA.26XcebFedCvxlXmczqAggo9_iFQ");
			await client.StartAsync();

            handler = new MessageHandler(client);

            await Task.Delay(-1);

		}
    }
}
