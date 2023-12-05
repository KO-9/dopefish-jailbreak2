using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Utils;
using CSTimer = CounterStrikeSharp.API.Modules.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrikeSharp.API.Modules.Timers;
using CounterStrikeSharp.API.Modules.Commands;

namespace JailbreakPlugin
{
    public class DopeMenu
    {
        private JailbreakPlugin _plugin;

        public DopeMenu(JailbreakPlugin plugin)
        {
            _plugin = plugin;
        }

        public void Initialize()
        {
            _plugin.AddCommand("dope", "Open Dopefish menu", DopeMenuHandler);
        }

        protected void DopeMenuHandler(CCSPlayerController? player, CommandInfo command)
        {
            player.PrintToChat("Opening dopefish menu");
            if (player == null || !player.is_valid())
            {
                return;
            }
            var dope_menu = new ChatMenu("Dopefish menu");

            dope_menu.AddMenuOption("VIP Menu", VipMenuHandler);
            dope_menu.AddMenuOption("Mod Menu", ModMenuHandler);
            ChatMenus.OpenMenu(player, dope_menu);
        }

        public void ModMenuHandler(CCSPlayerController player, ChatMenuOption option)
        {
            if (player == null || !player.is_valid())
            {
                return;
            }

            var mod_menu = new ChatMenu("Moderator Menu");
            mod_menu.AddMenuOption("Kick", VipMenuCallbackHandler);
            ChatMenus.OpenMenu(player, mod_menu);
        }

        public void VipMenuHandler(CCSPlayerController player, ChatMenuOption option)
        {
            if (player == null || !player.is_valid())
            {
                return;
            }

            var vip_menu = new ChatMenu("VIP Menu");
            vip_menu.AddMenuOption("Votemap", VipMenuCallbackHandler);
            ChatMenus.OpenMenu(player, vip_menu);
        }

        public void VipMenuCallbackHandler(CCSPlayerController player, ChatMenuOption option)
        {
            if (player == null || !player.is_valid())
            {
                return;
            }

            var vip_menu = new ChatMenu("VIP Menu");
            vip_menu.AddMenuOption("Map one", VipMenuCallbackHandler);
            ChatMenus.OpenMenu(player, vip_menu);
        }
    }
}
