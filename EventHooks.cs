using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Utils;
using CSTimer = CounterStrikeSharp.API.Modules.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrikeSharp.API.Modules.Timers;

namespace JailbreakPlugin
{
    public class EventHooks
    {
        private JailbreakPlugin _plugin;

        public EventHooks(JailbreakPlugin plugin)
        {
            _plugin = plugin;
        }

        public void Initialize()
        {
            _plugin.RegisterEventHandler<EventPlayerDeath>(PlayerDeathHandler);
            _plugin.RegisterEventHandler<EventPlayerSpawn>(PlayerSpawnHandler);
            _plugin.RegisterEventHandler<EventPlayerSpawned>(PlayerSpawnedHandler);
        }

        private HookResult PlayerSpawnedHandler(EventPlayerSpawned @event, GameEventInfo _)
        {
            var player = @event.Userid;

            if (!player.IsValid || !player.PlayerPawn.IsValid || player.IsBot)
            {
                Server.PrintToConsole("Nope");
                return HookResult.Continue;
            }

            //int to string
            var teamOne = player.TeamNum.ToString();
            var teamTwo = player.PendingTeamNum.ToString();

            _plugin.AddTimer(0.5f, () => player.RemoveWeapons());

            Server.PrintToConsole("SPAWNED: " + teamOne + " | " + teamTwo);

            return HookResult.Continue;
        }

        private HookResult PlayerSpawnHandler(EventPlayerSpawn @event, GameEventInfo _)
        {
            var player = @event.Userid;

            if (!player.IsValid || !player.PlayerPawn.IsValid || player.IsBot)
            {
                Server.PrintToConsole("Nope2");
                return HookResult.Continue;
            }

            //int to string
            var teamOne = player.TeamNum.ToString();
            var teamTwo = player.PendingTeamNum.ToString();

            Server.PrintToConsole("SPAWN:" + teamOne + " | " + teamTwo);

            //if T

            _plugin.AddTimer(0.5f, () => player.RemoveWeapons());

            return HookResult.Continue;
        }

        private HookResult PlayerDeathHandler(EventPlayerDeath @event, GameEventInfo _)
        {
            var attacker = @event.Attacker;
            var victim = @event.Userid;
            var headshot = @event.Headshot;

            if (attacker.IsValid && victim.IsValid && (attacker != victim) && !attacker.IsBot)
            {
            }

            return HookResult.Continue;
        }
    }
}
