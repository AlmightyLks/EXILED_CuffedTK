using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ToggleDamagePrevention : ICommand
    {
        public string Command { get; } = "pdmg";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Toggle Damage Prevention -> \"pdmg\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CuffedTK.Instance.Config.PreventDamage = !CuffedTK.Instance.Config.PreventDamage;
            response = "Prevent Damage: " + CuffedTK.Instance.Config.PreventDamage;
            return true;
        }
    }
}
