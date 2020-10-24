using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class ToggleDamagePrevention : ICommand
    {
        public string Command { get; } = "pdmg";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Toggle Damage Prevention -> \"pdmg\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CuffedTk.SharedConfig.PreventDamage = !CuffedTk.SharedConfig.PreventDamage;
            response = "Prevent Damage: " + CuffedTk.SharedConfig.PreventDamage;
            return true;
        }
    }
}
