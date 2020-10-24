using ExPlayerEvents = Exiled.Events.Handlers.Player;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace CuffedTK
{
    internal class CuffedTK : Plugin<Config>
    {
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        internal static Config SharedConfig { get; set; }
        private Handlers.Player _player;

        public override void OnEnabled()
        {
            if (SharedConfig is null)
                SharedConfig = Config;

            Log.Info("<AlmightyLks> Plugin Loaded");

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
            _player = new Handlers.Player();
            
            ExPlayerEvents.Died += _player.OnPlayerDeath;
            ExPlayerEvents.Hurting += _player.OnPlayerHurt;
        }
        private void UnregisterEvents()
        {
            ExPlayerEvents.Died -= _player.OnPlayerDeath;
            ExPlayerEvents.Hurting -= _player.OnPlayerHurt;

            _player = null;
        }
    }
}
