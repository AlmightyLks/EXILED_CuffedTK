using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class ToggleDamageReflection : ICommand
    {
        public string Command { get; } = "rdmg";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Toggle Damage Reflection -> \"rdmg\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CuffedTk.SharedConfig.ReflectDamage = !CuffedTk.SharedConfig.ReflectDamage;
            response = "Reflect Damage: " + CuffedTk.SharedConfig.ReflectDamage;

            return true;
        }
    }
}
