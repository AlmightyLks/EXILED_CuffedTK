using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.IO;
using System.Net;
using Utf8Json;

namespace CuffedTK.Handlers
{
    internal class Player
    {
        private WebRequest _webRequest;

        internal void OnPlayerDeath(DiedEventArgs ev)
        {
            if (!ev.Target.ValidHurt(ev.Killer))
                return;

            string outputMessage = $"\nWas cuffed: {ev.Target.IsCuffed}" +
                                   $"\nVictim: {ev.Target.Nickname}" +
                                   $"\nVictim ID: {ev.Target.UserId}" +
                                   $"\nKiller: {ev.Killer.Nickname}" +
                                   $"\nKiller ID: {ev.Killer.UserId}";

            if (RoleTypeHelper.CheckCuffedCase(ev.Target, ev.Killer))
            {
                if (!String.Equals(CuffedTk.SharedConfig.WebhookUrl, String.Empty))
                    SendWebhookMessage(ev.Target.UserId, ev.Target.Nickname, ev.Killer.UserId, ev.Killer.Nickname);

                ev.Target.SendConsoleMessage(outputMessage, "Red");

                Log.Info(outputMessage);

                if (CuffedTk.SharedConfig.AutoJail)
                {
                    ev.Killer.SetRole(RoleType.Tutorial);
                }
            }
        }
        internal void OnPlayerHurt(HurtingEventArgs ev)
        {
            if (!ev.Target.ValidHurt(ev.Attacker))
                return;

            if (RoleTypeHelper.CheckCuffedCase(ev.Target, ev.Attacker))
            {
                if (CuffedTk.SharedConfig.ReflectDamage)
                {
                    ev.Attacker.Hurt(ev.Amount, ev.DamageType);
                    ev.Amount = 0;
                }
                else if (CuffedTk.SharedConfig.PreventDamage)
                {
                    ev.Amount = 0;
                }
            }
        }
        private void SendWebhookMessage(string victimID, string victimName, string killerID, string killerName)
        {
            _webRequest = WebRequest.Create(CuffedTk.SharedConfig.WebhookUrl);

            if (_webRequest == null)
            {
                Log.Error("Webhook failure");
                return;
            }

            _webRequest.ContentType = "application/json";
            _webRequest.Method = "POST";

            using (var sw = new StreamWriter(_webRequest.GetRequestStream()))
            {
                var json = JsonSerializer.ToJsonString(new DiscordWebhook(String.Empty, "CuffedTK", String.Empty, false, new DiscordEmbed[1]
                {
                    new DiscordEmbed("CuffedTK", "rich", CheaterReport.ServerName, 14423100, new DiscordEmbedField[4]
                    {
                      new DiscordEmbedField("Victim Name", victimName, false),
                      new DiscordEmbedField("Victim ID", victimID, false),
                      new DiscordEmbedField("Killer Name", killerName, false),
                      new DiscordEmbedField("Killer ID", killerID, false)
                    })
                }));
                sw.Write(json);
            }
            var response = _webRequest.GetResponse() as HttpWebResponse;

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
                Log.Error("Webhook failure");
        }
    }
}
