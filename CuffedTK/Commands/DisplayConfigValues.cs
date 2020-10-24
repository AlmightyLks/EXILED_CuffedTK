using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class DisplayConfigValues : ICommand
    {
        public string Command { get; } = "ctkinfo";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "View all Configs & their values -> \"ctkinfo\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"Auto Jail: {CuffedTk.SharedConfig.AutoJail}\n " +
                       $"Prevent Damage: {CuffedTk.SharedConfig.PreventDamage}\n " +
                       $"Reflect Damage: {CuffedTk.SharedConfig.ReflectDamage}";
            return true;
        }
    }
}
