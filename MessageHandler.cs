using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace bot
{
    class MessageHandler
    {
        private CommandService service;

        private DiscordSocketClient _client;

        public MessageHandler(DiscordSocketClient client)
        {
            _client = client;

            service = new CommandService();
            service.AddModulesAsync(Assembly.GetEntryAssembly());

            client.MessageReceived += HandleMessage;
        }

        private async Task HandleMessage(SocketMessage s)
        {
            var msg = s as SocketUserMessage;

            if (msg == null) return;

            var context = new SocketCommandContext(_client, msg);

            int argPos = 0;

            if(msg.HasCharPrefix('!', ref argPos))
            {
                var result = await service.ExecuteAsync(context, argPos);

                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }
    }
}
