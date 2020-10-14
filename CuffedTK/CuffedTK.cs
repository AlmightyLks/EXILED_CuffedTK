using ExPlayerEvents = Exiled.Events.Handlers.Player;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace CuffedTK
{
    public class CuffedTK : Plugin<Config>
    {
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public static Config SharedConfig { get; set; }
        private Handlers.Player _Player;

        public override void OnEnabled()
        {
            if (SharedConfig is null)
                SharedConfig = Config;

            Log.Info("<AlmightyLks> CuffedTK");

            RegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _Player = new Handlers.Player();

            ExPlayerEvents.Died += _Player.OnPlayerDeath;
            ExPlayerEvents.Hurting += _Player.OnPlayerHurt;
        }
        private void UnregisterEvents()
        {
            ExPlayerEvents.Died -= _Player.OnPlayerDeath;
            ExPlayerEvents.Hurting -= _Player.OnPlayerHurt;
            _Player = null;
        }
    }
}
