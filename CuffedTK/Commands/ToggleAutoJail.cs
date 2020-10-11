using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ToggleAutoJail : ICommand
    {
        public string Command { get; } = "autojail";
        public string[] Aliases { get; } = new[] { "aj" };
        public string Description { get; } = "Toggle Auto Jail -> \"autojail\" or \"aj\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CuffedTK.Instance.Config.AutoJail = !CuffedTK.Instance.Config.AutoJail;
            response = "Auto jail: " + CuffedTK.Instance.Config.AutoJail;
            return true;
        }
    }
}
