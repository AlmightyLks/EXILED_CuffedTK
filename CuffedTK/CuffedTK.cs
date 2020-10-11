using Exiled.API.Enums;
using Exiled.API.Features;
using System;

using ExServerEvents = Exiled.Events.Handlers.Server;
using ExPlayerEvents = Exiled.Events.Handlers.Player;

namespace CuffedTK
{
    public class CuffedTK : Plugin<Config>
    {
        private static readonly Lazy<CuffedTK> LazyInstance = new Lazy<CuffedTK>(() => new CuffedTK());

        public static CuffedTK Instance => LazyInstance.Value;
        public override PluginPriority Priority { get; } = PluginPriority.Highest;

        private Handlers.Player _Player;

        private CuffedTK() { }

        public override void OnEnabled()
        {
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
