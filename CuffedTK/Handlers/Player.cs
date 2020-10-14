﻿using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace CuffedTK.Handlers
{
    public class Player
    {
        public Player() { }

        public void OnPlayerDeath(DiedEventArgs ev)
        {
            if (!ev.Target.ValidHurt(ev.Killer))
                return;

            string outputMessage = $"\nWas cuffed: {ev.Target.IsCuffed}" +
                                   $"\nVictim ID: {ev.Target.UserId}" +
                                   $"\nVictim: {ev.Target.Nickname}" +
                                   $"\nKiller ID: {ev.Killer.UserId}" +
                                   $"\nKiller: {ev.Killer.Nickname}";

            if (RoleTypeHelper.CheckCuffedCase(ev.Target, ev.Killer))
            {
                ev.Target.SendConsoleMessage(outputMessage, "Red");

                Log.Info(outputMessage);

                if (CuffedTK.SharedConfig.AutoJail)
                {
                    ev.Killer.SetRole(RoleType.Tutorial);
                }
            }
        }
        public void OnPlayerHurt(HurtingEventArgs ev)
        {
            if (!ev.Target.ValidHurt(ev.Attacker))
                return;

            if (RoleTypeHelper.CheckCuffedCase(ev.Target, ev.Attacker))
            {
                if (CuffedTK.SharedConfig.ReflectDamage)
                {
                    ev.Attacker.Hurt(ev.Amount, ev.DamageType);
                    ev.Amount = 0;
                }
                else if (CuffedTK.SharedConfig.PreventDamage)
                {
                    ev.Amount = 0;
                }
            }
        }
    }
}
