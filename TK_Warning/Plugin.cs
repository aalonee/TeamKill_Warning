using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.Commands.Reload;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Events;

namespace Template
{
    public sealed class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override string Name { get; } = "TeamKill Warning";

        public override string Author { get; } = "alone";

        public override string Prefix { get; } = "TKWarning";

        public override void OnEnabled()
        {
            base.OnEnabled();
            Exiled.Events.Handlers.Player.Hurting += OnHurt;
            Exiled.Events.Handlers.Player.Dying += OnTK;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.Hurting -= OnHurt;
            Exiled.Events.Handlers.Player.Dying -= OnTK;
        }

        public void OnHurt(HurtingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Player != null && ev.Attacker != ev.Player)
            {
                if (ev.Attacker.Role.Team == ev.Player.Role.Team)
                {
                    ev.Attacker.ShowHint(Config.AttackerShooting.Replace("%target%", ev.Player.Nickname), Config.ShotDuration);
                    ev.Player.ShowHint(Config.TargetShot.Replace("%attacker%", ev.Attacker.Nickname), Config.ShotDuration);
                }
            }
        }

        public void OnTK(DyingEventArgs ev)
        {
            if (ev.Attacker != null && ev.Player != null && ev.Attacker != ev.Player)
            {
                if (ev.Attacker.Role.Team == ev.Player.Role.Team)
                {
                    ev.Attacker.ShowHint(Config.AttackerKilling.Replace("%target%", ev.Player.Nickname), Config.KillDuration);
                    ev.Player.ShowHint(Config.TargetKilled.Replace("%attacker%", ev.Attacker.Nickname), Config.KillDuration);
                }
            }
        }
    }
}