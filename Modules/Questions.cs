using Discord.Commands;
using System.Threading.Tasks;

namespace bot.Modules
{
    public class Questions : ModuleBase<SocketCommandContext>
    {
        [Command("Test")]
        public async Task testfunc()
        {
            await Context.Channel.SendMessageAsync("Работает");
        }
    }
}
