using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailbreakPlugin
{
    public class Cash
    {
        private JailbreakPlugin _plugin;
        protected CCSPlayerController[] players = new CCSPlayerController[64];

        public Cash(JailbreakPlugin plugin)
        {
            _plugin = plugin;
        }


    }
}