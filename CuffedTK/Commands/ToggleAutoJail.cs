using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class ToggleAutoJail : ICommand
    {
        public string Command { get; } = "autojail";
        public string[] Aliases { get; } = new[] { "aj" };
        public string Description { get; } = "Toggle Auto Jail -> \"autojail\" or \"aj\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CuffedTK.SharedConfig.AutoJail = !CuffedTK.SharedConfig.AutoJail;
            response = "Auto jail: " + CuffedTK.SharedConfig.AutoJail;
            return true;
        }
    }
}
