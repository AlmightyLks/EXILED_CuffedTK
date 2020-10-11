using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class DisplayConfigValues : ICommand
    {
        public string Command { get; } = "ctkinfo";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "View all Configs & their values -> \"ctkinfo\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"\nAuto Jail: {CuffedTK.Instance.Config.AutoJail}\n Prevent Damage: {CuffedTK.Instance.Config.PreventDamage}\n Reflect Damage: {CuffedTK.Instance.Config.ReflectDamage}";
            return true;
        }
    }
}
