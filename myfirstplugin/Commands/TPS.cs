using System;
using CommandSystem;
using System.Linq;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace myfirstplugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class TPS : ICommand
    {
        public string Command => "TPS";

        public string[] Aliases { get; } = Array.Empty<string>();

        public string Description => "tries to show servers current tps";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("mfp.tps"))
            {
                response = $"<color=red>you dont have premmisions!</color>";
            }

            response = $"{Server.Tps}/{ServerStatic.ServerTickrate}";
            return true;
        }
    }
}
