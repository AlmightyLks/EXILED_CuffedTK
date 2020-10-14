using CommandSystem;
using System;

namespace CuffedTK.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ToggleDamageReflection : ICommand
    {
        public string Command { get; } = "rdmg";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Toggle Damage Reflection -> \"rdmg\"";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            CuffedTK.SharedConfig.ReflectDamage = !CuffedTK.SharedConfig.ReflectDamage;
            response = "Reflect Damage: " + CuffedTK.SharedConfig.ReflectDamage;

            return true;
        }
    }
}
