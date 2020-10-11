using Exiled.API.Interfaces;
using System.ComponentModel;

namespace CuffedTK
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        [Description("Auto jailing on Cuffed Teamkilling")]
        public bool AutoJail { get; set; } = false;

        [Description("Damage prevention on attempted Cuffed Teamkilling")]
        public bool PreventDamage { get; set; } = false;

        [Description("Damage reflection on attempted Cuffed Teamkilling")]
        public bool ReflectDamage { get; set; } = false;
    }
}
