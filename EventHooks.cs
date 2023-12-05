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
        private Database _db;

        public EventHooks(JailbreakPlugin plugin, Database db)
        {
            _plugin = plugin;
            _db = db;
        }

        public void Initialize()
        {
            _plugin.RegisterEventHandler<EventPlayerDeath>(PlayerDeathHandler);
            _plugin.RegisterEventHandler<EventPlayerSpawn>(PlayerSpawnHandler);
            _plugin.RegisterEventHandler<EventPlayerConnect>(OnPlayerConnect);
        }

        private HookResult PlayerSpawnHandler(EventPlayerSpawn @event, GameEventInfo _)
        {
            CCSPlayerController? player = @event.Userid;

            if (player.is_valid() && !player.IsBot)
            {
                //copy EventPlayerSpawn to a new object
                _plugin.AddTimer(0.5f, () => _plugin._jailCore.playerSpawn(player, _));
            }

            return HookResult.Continue;
        }

        private HookResult PlayerDeathHandler(EventPlayerDeath @event, GameEventInfo _)
        {
            var attacker = @event.Attacker;
            var victim = @event.Userid;
            var headshot = @event.Headshot;

            if (attacker.IsValid && victim.IsValid && (attacker != victim) && !attacker.IsBot)
            {
                //@event
                _plugin._jailCore.playerDeath(attacker, victim, headshot, _);
            }

            return HookResult.Continue;
        }

        private HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
        {
            CCSPlayerController? player = @event.Userid;

            if (player != null && player.is_valid())
            {
                _plugin._jailCore.playerConnect(player, info);
            }

            return HookResult.Continue;
        }
    }
}
