using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailbreakPlugin
{
    public class JailCore
    {
        private JailbreakPlugin _plugin;
        JailPlayer[] jail_players = new JailPlayer[64];


        public JailCore(JailbreakPlugin plugin)
        {
            _plugin = plugin;

            for (int p = 0; p < jail_players.Length; p++)
            {
                jail_players[p] = new JailPlayer();
            }
        }

        JailPlayer? playerToJailPlayer(CCSPlayerController? player)
        {
            if (!player.is_valid() || player == null)
            {
                return null;
            }

            var slot = player.slot();

            if (slot == null)
            {
                return null;
            }

            return jail_players[slot.Value];
        }

        public void playerDeath(EventPlayerDeath @event, GameEventInfo _)
        {
            var attacker = @event.Attacker;
            var victim = @event.Userid;
            var headshot = @event.Headshot;

            if (attacker.IsValid && victim.IsValid && (attacker != victim) && !attacker.IsBot && victim.is_ct())
            {
                //var cashAmt = KILL_CASH_AMT;
                //check if knife and award more
                //check if headshot and award more
                //_plugin._db.give_cash(victim, cashAmt, CASH_REASON_KILL);
            }

        }

        public void playerSpawn(EventPlayerSpawn @event, GameEventInfo _)
        {
            var player = @event.Userid;
        }

        public void playerConnect(EventPlayerConnect @event, GameEventInfo info)
        {
            var player = @event.Userid;
            var slot = player.slot();

            //if (slot != null)
            //{
            //    var jail_player = jail_players[slot.Value];
            //    jail_player.load(player);
            //    jail_player.Cash =  _plugin._db.load_cash(jail_players[slot.Value]);
            //}
        }
    }
}
